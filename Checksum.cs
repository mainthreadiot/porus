using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Porus
{
    
    public partial class Checksum : Form
    {
        public Checksum()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string data = txtInputChecksum.Text;
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            try
            {
                byte simpleChecksum = CalculateSimpleChecksum(dataBytes);
                uint crc32Checksum = CRC32.CalculateCRC32(dataBytes);
                string md5Checksum = CalculateMD5Checksum(data);
                string sha256Checksum = CalculateSHA256Checksum(data);

                txtSimpleChecksum.Text = simpleChecksum.ToString();
                txtCRC.Text = crc32Checksum.ToString();
                txtmdHecksum.Text = md5Checksum.ToString();
                txtSHA.Text = sha256Checksum.ToString();
            }
            catch
            {
                txtSimpleChecksum.Text = "Data Error";
                txtCRC.Text = "Data Error";
                txtmdHecksum.Text = "Data Error";
                txtSHA.Text = "Data Error";
            }
        }

        public static string CalculateMD5Checksum(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        public static string CalculateSHA256Checksum(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        public static byte CalculateXORChecksum(byte[] data)
        {
            byte checksum = 0;
            foreach (var byteValue in data)
            {
                checksum ^= byteValue;
            }
            return checksum;
        }
        public static byte CalculateSimpleChecksum(byte[] data)
        {
            byte checksum = 0;
            foreach (var byteValue in data)
            {
                checksum += byteValue;
            }
            return checksum;
        }
        public class CRC32
        {
            private static readonly uint[] Crc32Table;

            static CRC32()
            {
                Crc32Table = new uint[256];
                const uint polynomial = 0xedb88320;

                // Generate the CRC32 table
                for (uint i = 0; i < 256; i++)
                {
                    uint crc = i;
                    for (uint j = 8; j > 0; j--)
                    {
                        if ((crc & 1) == 1)
                            crc = (crc >> 1) ^ polynomial;
                        else
                            crc >>= 1;
                    }
                    Crc32Table[i] = crc;
                }
            }

            public static uint CalculateCRC32(byte[] data)
            {
                uint crc = 0xffffffff;

                foreach (byte b in data)
                {
                    byte tableIndex = (byte)(((crc) & 0xff) ^ b);
                    crc = Crc32Table[tableIndex] ^ (crc >> 8);
                }

                return ~crc;
            }
        }

        private void Checksum_Load(object sender, EventArgs e)
        {
            
        }
            
        private void txtInputChecksum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
              
            }
        }
    }
}
