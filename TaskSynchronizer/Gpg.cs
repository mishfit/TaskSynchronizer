using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.IO;
using Org.BouncyCastle.Utilities.IO;

namespace TaskSynchronizer
{
    internal class Gpg
    {


    public static void DecryptFile(string inputFilePath, string outputFilePath, string privateKeyPath, string passphrase)
    {
        using (Stream inputStream = File.OpenRead(inputFilePath))
        using (Stream keyIn = File.OpenRead(privateKeyPath))
        using (Stream outputStream = File.Create(outputFilePath))
        {
            Decrypt(inputStream, keyIn, passphrase.ToCharArray(), outputStream);
        }
    }

    private static void Decrypt(Stream inputStream, Stream privateKeyStream, char[] passPhrase, Stream outputStream)
    {
        inputStream = PgpUtilities.GetDecoderStream(inputStream);

        PgpObjectFactory pgpF = new PgpObjectFactory(inputStream);
        PgpEncryptedDataList enc;

        PgpObject o = pgpF.NextPgpObject();
        if (o is PgpEncryptedDataList)
        {
            enc = (PgpEncryptedDataList)o;
        }
        else
        {
            enc = (PgpEncryptedDataList)pgpF.NextPgpObject();
        }

        PgpPrivateKey privateKey = null;
        PgpPublicKeyEncryptedData pbe = null;
        PgpSecretKeyRingBundle secretKeyRingBundle = new PgpSecretKeyRingBundle(PgpUtilities.GetDecoderStream(privateKeyStream));

        foreach (PgpPublicKeyEncryptedData pked in enc.GetEncryptedDataObjects())
        {
            privateKey = FindSecretKey(secretKeyRingBundle, pked.KeyId, passPhrase);

            if (privateKey != null)
            {
                pbe = pked;
                break;
            }
        }

        if (privateKey == null)
            throw new ArgumentException("Secret key for message not found.");

        Stream clear = pbe.GetDataStream(privateKey);
        PgpObjectFactory plainFact = new PgpObjectFactory(clear);
        PgpObject message = plainFact.NextPgpObject();

        if (message is PgpLiteralData literalData)
        {
            Stream unc = literalData.GetInputStream();
            Streams.PipeAll(unc, outputStream);
        }
        else
        {
            throw new PgpException("Message is not a simple encrypted file.");
        }

        if (pbe.IsIntegrityProtected() && !pbe.Verify())
        {
            throw new PgpException("Message failed integrity check.");
        }
    }

    private static PgpPrivateKey FindSecretKey(PgpSecretKeyRingBundle pgpSec, long keyId, char[] pass)
    {
        PgpSecretKey pgpSecKey = pgpSec.GetSecretKey(keyId);
        return pgpSecKey?.ExtractPrivateKey(pass);
    }
}
}
