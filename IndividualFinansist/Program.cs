using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataTable = System.Data.DataTable;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using IndividualFinansist.GeneralForms;

namespace IndividualFinansist
{
    class ManipulationDB
    {
        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);

        //запросы на отображение данных

        public string queryBank = "SELECT ROW_NUMBER() over (ORDER BY [Банк].[ИД] ASC) [Порядковый номер], " +
            "Паспорт.ФИО, Паспорт.СиН, Паспорт.Идентификатор, Организация.Наименование AS [Наименование организации]," +
            " Банк.Должность, Банк.[Дата регистрации] AS [Дата регистрации накопления], Банк.Сумма, Валюта.[Сокращенное наименование] AS [Валюта] " +
            "FROM Организация INNER JOIN Банк ON Организация.ИД = Банк.Организация " +
            "INNER JOIN Валюта ON Валюта.ИД=Банк.Валюта" +
            " INNER JOIN Паспорт ON Банк.Паспорт=Паспорт.ИД";
        public string queryMoney = "SELECT ROW_NUMBER() over (ORDER BY [Валюта].[ИД] ASC) [Порядковый номер], " +
            "Валюта.Наименование AS [Полное наименование], Валюта.[Сокращенное наименование] " +
            "FROM Валюта";
        public string queryFinOperation = "SELECT ROW_NUMBER() over (ORDER BY [Операция].[ИД] ASC) [Порядковый номер], " +
            "Операция.Наименование AS [Наименование операции] " +
            "FROM Операция";
        public string queryOrganization = "SELECT ROW_NUMBER() over (ORDER BY [Организация].[ИД] ASC) [Порядковый номер], Организация.Наименование AS [Наименование организации], " +
            "Организация.[Дата регистрации], Организация.[Юридический адрес], Организация.[Фактический адрес]" +
            " FROM Организация";
        public string queryUser = "SELECT ROW_NUMBER() over (ORDER BY [Пользователь].[ИД] ASC) [Порядковый номер]," +
            " Логин, Пароль, Администрирование " +
            "FROM Пользователь";
        public string queryPlus = "SELECT ROW_NUMBER() over (ORDER BY [Приход].[ИД] ASC) [Порядковый номер], " +
            "Паспорт.ФИО, Паспорт.СиН, Паспорт.Идентификатор," +
            " Организация.Наименование AS [Организация], Операция.Наименование AS [Операция], " +
            "Приход.Описание AS [Описание операции], Приход.Сумма, Валюта.[Сокращенное наименование] AS Валюта" +
            " FROM Приход INNER JOIN Паспорт ON Паспорт.ИД=Приход.Банк " +
            "INNER JOIN Операция ON Операция.ИД=Приход.Наименование INNER JOIN Валюта ON Валюта.ИД=Приход.Валюта " +
            "INNER JOIN Банк ON Приход.Банк=Банк.ИД " +
            "INNER JOIN Организация ON Организация.ИД=Банк.Организация";
        public string queryMinus = "SELECT ROW_NUMBER() over (ORDER BY Расход.[ИД] ASC) [Порядковый номер], " +
            "Паспорт.ФИО, Паспорт.СиН, Паспорт.Идентификатор, Организация.Наименование AS Организация, " +
            "Операция.Наименование AS Операция, Расход.Описание AS [Описание операции], " +
            "Расход.Сумма, Валюта.[Сокращенное наименование] AS Валюта FROM Расход " +
            "INNER JOIN Паспорт ON Паспорт.ИД=Расход.Банк " +
            "INNER JOIN Операция ON Операция.ИД=Расход.Наименование " +
            "INNER JOIN Валюта ON Валюта.ИД=Расход.Валюта " +
            "INNER JOIN Банк ON Расход.Банк=Банк.ИД " +
            "INNER JOIN Организация ON Организация.ИД=Банк.Организация";

        public string queryMoneySize = "SELECT ROW_NUMBER() OVER (ORDER BY КВ.[ИД] ASC) [Порядковый номер], " +
            "КВ.Единица1, В1.[Сокращенное наименование] AS Валюта, КВ.Единица2, " +
            "В2.[Сокращенное наименование] AS Валюта2 FROM [Курс валют] AS КВ " +
            "INNER JOIN Валюта AS В1 ON В1.ИД = КВ.Валюта1 " +
            "INNER JOIN Валюта AS В2 ON В2.ИД = КВ.Валюта2";

        public string queryPassport = "SELECT ROW_NUMBER() OVER (ORDER BY Паспорт.[ИД] ASC) [Порядковый номер], " +
            "ФИО, СиН, Идентификатор FROM Паспорт";

        //запросы на удаление данных

        public string queryBankDel = "DELETE FROM Банк WHERE ИД=";
        public string queryMoneyDel = "DELETE FROM Валюта WHERE ИД=";
        public string queryOperationDel = "DELETE FROM Операция WHERE ИД=";
        public string queryOrganizationDel = "DELETE FROM Организация WHERE ИД=";
        public string queryUserDel = "DELETE FROM Пользователь WHERE ИД=";
        public string queryPlusDel = "DELETE FROM Приход WHERE ИД=";
        public string queryMinusDel = "DELETE FROM Расход WHERE ИД=";
        public string queryMoneySizeDel = "DELETE FROM [Курс валют] WHERE ИД=";
        public string queryPassportDel = "DELETE FROM Паспорт WHERE ИД=";

        public void Select(string query, DataGridView dGV)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                connect.Open();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dGV.DataSource = dt;
                connect.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public void SelectComboBox(string query, ComboBox cb, string name, string id)
        {
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                cb.DataSource = dt;
                cb.DisplayMember = name;
                cb.ValueMember = id;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка программы:");
            }
            finally
            {
                connect.Close();
            }
        }

        public void Insert(string query)
        {
            try
            {
                connect.Open();
                SqlCommand comm = new SqlCommand(query, connect);
                comm.ExecuteScalar();
                connect.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        //public void Update(DataGridView dG, string queryUpd)
        //{
        //    List<int> Num = new List<int>();
        //    try
        //    {
        //        connect.Open();
        //        if (dG.RowCount != 0)
        //        {
        //            if (dG.SelectedCells.Count != 0)
        //            {
        //                Num.Add(Convert.ToInt32(dG[0, dG.CurrentCell.RowIndex].Value));
        //            }
        //        }

        //        for (int i = 0; i < Num.Count; i++)
        //        {
        //            queryUpd = queryUpd + Num[i];
        //            SqlCommand SQLcmd = new SqlCommand(queryUpd, connect);
        //            SQLcmd.ExecuteScalar();
        //        }
        //        Num.Clear();
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show(ex.Message, "Ошибка работы с БД");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Ошибка программы");
        //    }
        //    finally
        //    {
        //        connect.Close();
        //        Num.Clear();
        //    }
        //}

        public void Delete(DataGridView dg, string query, string ID)
        {
            List<int> Num = new List<int>();
            try
            {
                connect.Open();
                if (dg.RowCount != 0)
                {
                    if (dg.SelectedCells.Count != 0)
                    {
                        Num.Add(Convert.ToInt32(ID));
                        dg.Rows.RemoveAt(dg.CurrentCell.RowIndex);
                    }
                }

                for (int i = 0; i < Num.Count; i++)
                {
                    SqlCommand SQLcmd = new SqlCommand(query + Num[i], connect);
                    SQLcmd.ExecuteScalar();
                }
                Num.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка программы");
            }
            finally
            {
                connect.Close();
                Num.Clear();
            }
        }

        public void DeleteWithVibor(DataGridView dG, string queryVibor, string querydel, string ID)
        {
            List<int> delNum = new List<int>();
            try
            {
                connect.Open();
                queryVibor = queryVibor + ID;
                SqlCommand SQLcmd = new SqlCommand(queryVibor, connect);
                if (Convert.ToString(SQLcmd.ExecuteScalar()) == "")
                {
                    if (dG.RowCount != 0)
                    {
                        if (dG.SelectedCells.Count != 0)
                        {
                            delNum.Add(Convert.ToInt32(ID));
                            dG.Rows.RemoveAt(dG.CurrentCell.RowIndex);
                        }
                    }

                    for (int i = 0; i < delNum.Count; i++)
                    {
                        querydel = querydel + delNum[i];
                        SQLcmd = new SqlCommand(querydel, connect);
                        SQLcmd.ExecuteScalar();
                    }
                }
                else
                {
                    MessageBox.Show("Вы не можете удалить данную строку, т.к. другая таблица зависит от данной строки!");
                }
                connect.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка программы");
            }
            finally
            {
                delNum.Clear();
                connect.Close();
            }
        }

        public string generationID(string query)
        {
            string ID = "";
            try
            {
                SqlCommand comm = new SqlCommand(query, connect);
                connect.Open();
                ID = comm.ExecuteScalar().ToString();
                connect.Close();
            }
            catch (SqlException exSQL)
            {
                MessageBox.Show(exSQL.Message, "Ошибка работы с базой данных:");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с приложением:");
            }
            finally
            {
                connect.Close();
            }

            return ID;
        }

        public void UpdateNoID(DataGridView dG, string queryUpd)
        {
            try
            {
                connect.Open();
                SqlCommand SQLcmd = new SqlCommand(queryUpd, connect);
                SQLcmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка программы");
            }
            finally
            {
                connect.Close();
            }
        }

        public void Update(string queryUpd)
        {
            try
            {
                connect.Open();
                try
                {      //чтение файла
                    string[] allText = File.ReadAllLines("index.txt"); //чтение всех строк файла в массив строк
                    foreach (string s in allText)
                    {   //вывод всех строк на консоль
                        queryUpd = queryUpd + s;
                        SqlCommand SQLcmd = new SqlCommand(queryUpd, connect);
                        SQLcmd.ExecuteScalar();
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка программы");
            }
            finally
            {
                connect.Close();
                File.Delete("index.txt");
            }
        }
    }

    class UsersTF
    {
        public static int user = 0;
    }

    class ConnDB
    {
        public static string conn = "";
    }

    public static class shifr_PBKDF2
    {
        // This constant is used to determine the keysize of the encryption algorithm in bits.
        // We divide this by 8 within the code below to get the equivalent number of bytes.
        private const int Keysize = 256;

        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;

        public static string Encrypt(string plainText, string passPhrase)
        {
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }

    class ManipulationProgramm
    {
        public void ZapisIndex(string ID)
        {
            //if (dGV.RowCount != 0)
            //{
            //    if (dGV.SelectedCells.Count != 0)
            //    {
            string fileName = "index.txt";                //пишем полный путь к файлу
            if (File.Exists(fileName) != true)
            {  //проверяем есть ли такой файл, если его нет, то создаем
                using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Create, FileAccess.Write)))
                {
                    sw.WriteLine(ID); //пишем строчку, или пишем что хотим
                }
            }
            else
            {                              //если файл есть, то откываем его и пишем в него 
                using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Open, FileAccess.Write)))
                {
                    (sw.BaseStream).Seek(0, SeekOrigin.End);         //идем в конец файла и пишем строку или пишем то, что хотим
                    sw.WriteLine(ID);
                }
            }
            //    }
            //}
        }

        public void Find(DataGridView numDat, ToolStripTextBox tltbNum)
        {
            try
            {
                if (tltbNum.Text != "")
                {
                    for (int i = 0; i < numDat.RowCount; i++)
                    {
                        numDat.Rows[i].Selected = false;
                        for (int j = 0; j < numDat.ColumnCount; j++)
                        {
                            if (numDat.Rows[i].Cells[j].Value != null)
                            {
                                if (numDat.Rows[i].Cells[j].Value.ToString().Contains(tltbNum.Text))
                                {
                                    numDat.Rows[i].Selected = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введите значение в строку поиска!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Попробуйте снова. Код ошибки:");
            }
        }

        public void Next(DataGridView dG)
        {
            if (dG.RowCount != 0)
            {
                if (dG.CurrentCell.RowIndex != dG.Rows.Count - 1)
                    dG.CurrentCell = dG[0, (dG.CurrentCell.RowIndex + 1)];
            }
        }

        public void Back(DataGridView dG)
        {
            if (dG.RowCount != 0)
            {
                if (dG.CurrentCell.RowIndex != 0)
                    dG.CurrentCell = dG[0, (dG.CurrentCell.RowIndex - 1)];
            }
        }

        public void NextUp(DataGridView dG)
        {
            if (dG.RowCount != 0)
            {
                dG.CurrentCell = dG[0, (dG.Rows.Count - 1)];
            }
        }

        public void BackUp(DataGridView dG)
        {
            if (dG.RowCount != 0)
            {
                dG.CurrentCell = dG[0, 0];
            }
        }
    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConnectionDB());
        }
    }
}
