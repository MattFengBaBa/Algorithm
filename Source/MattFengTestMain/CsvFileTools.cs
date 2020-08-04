using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MattFengTestMain
{
    /// <summary>
    /// 生成csv文件
    /// </summary>
    public class CsvFileTools
    {
        private FileStream fileStream;
        private readonly string PathAndFileName = string.Empty;
        public CsvFileTools(string path,string fileName,bool cover = false)
        {
            if (path[path.Length - 1] != '\\') path += '\\';
            if (fileName.Length < 5) fileName += ".csv";
            if (!(fileName.IndexOf(".csv", fileName.Length - 4) > 0 || fileName.IndexOf(".CSV", fileName.Length - 4) > 0))
                fileName += ".csv";
            if (cover)
                fileStream = File.Create(path + fileName);
            else
            {
                fileStream = File.Open(path + fileName, FileMode.OpenOrCreate,FileAccess.ReadWrite);
                if (fileStream.Length > 0)
                    fileStream.Position = fileStream.Length;
            }
            PathAndFileName = path + fileName;
        }
        public CsvFileTools(string pathAndFileName, bool cover = false)
        {
            if (cover)
                fileStream = File.Create(pathAndFileName);
            else
            {
                string path = Path.GetDirectoryName(pathAndFileName);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                fileStream = File.Open(pathAndFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                if (fileStream.Length > 0)
                    fileStream.Position = fileStream.Length;
            }
            PathAndFileName = pathAndFileName;
        }
        public bool AddRow(dynamic rowArray)
        {
            try
            {
                string rowStr = string.Empty;
                if (rowArray != null)
                    foreach (object cell in rowArray)
                    {
                        string cellStr = cell == null ? string.Empty : cell.ToString();
                        cellStr = cellStr.Replace("\"", "\"\"");
                        if (cellStr.IndexOf(',') != -1 || cellStr.IndexOf('\r') != -1 || cellStr.IndexOf('\n') != -1 || cellStr.IndexOf('"') != -1)
                            cellStr = '"' + cellStr + '"';
                        rowStr += cellStr + ',';
                    }
                if (rowStr.Length > 0)
                    rowStr = rowStr.Substring(0, rowStr.Length - 1) + "\r\n";
                byte[] buffer = Encoding.Default.GetBytes(rowStr);
                fileStream.Write(buffer, 0, buffer.Length);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditCell(dynamic cell, int row, int cloumn)
        {
            if (ReadTable(out List<string[]> table))
            {
                if (table[row].Length <= cloumn)
                {
                    string[] newOne = new string[cloumn + 1];
                    Array.Copy(table[row], newOne, table[row].Length);
                    table[row] = newOne;
                }
                table[row][cloumn] = ((object)cell).ToString();
                return SaveTable(table);
            }
            else
            {
                return false;
            }
        }
        public bool ReadTable(out List<string[]> table)
        {
            string data = string.Empty;
            fileStream.Position = 0;
            if (fileStream.Length < int.MaxValue)
            {
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                data = Encoding.Default.GetString(buffer);
            }
            else
            {
                long restByte = fileStream.Length;
                while (restByte > int.MaxValue)
                {
                    byte[] buffer = new byte[int.MaxValue];
                    fileStream.Read(buffer, 0, buffer.Length);
                    data += Encoding.Default.GetString(buffer);
                    restByte -= int.MaxValue;
                }
                if (restByte > 0)
                {
                    byte[] buffer = new byte[restByte];
                    fileStream.Read(buffer, 0, buffer.Length);
                    data += Encoding.Unicode.GetString(buffer);
                }
            }
            fileStream.Close();
            table = new List<string[]>();
            string tempData = data;
            List<string> spliptStr = new List<string>();
            //tempData = tempData.Substring(1);
            while (tempData.Length > 0)
            {
                bool rowEnd = false;
                while (!rowEnd)
                {
                    int start = 0;
                    int index = tempData.IndexOf(',');
                    int length = 1;
                    string tempStr = string.Empty;
                    if (tempData[0] == '\"')
                    {
                        start = 1;
                        index = tempData.IndexOf("\",");
                        length = 2;
                        if (index == -1)
                        {
                            rowEnd = true;
                            index = tempData.IndexOf("\"\r\n");
                            length = 3;
                            if (index == -1)
                            {
                                index = tempData.IndexOf("\"\r");
                                length = 2;
                                if (index == -1)
                                {
                                    index = tempData.IndexOf("\"\n");
                                    //length = 2;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (index > 0)
                            tempStr = tempData.Substring(0, index);
                        else if (index == 0)
                            tempStr = string.Empty;
                        else
                            tempStr = tempData;
                        if (tempStr.IndexOf("\r\n") != -1)
                        {
                            index = tempStr.IndexOf("\r\n");
                            length = 2;
                            rowEnd = true;
                        }
                        else
                        {
                            if (tempStr.IndexOf('\r') != -1)
                            {
                                index = tempStr.IndexOf('\r');
                                length = 1;
                                rowEnd = true;
                            }
                            else
                            {
                                if (tempStr.IndexOf('\n') != -1)
                                {
                                    index = tempStr.IndexOf('\n');
                                    length = 1;
                                    rowEnd = true;
                                }
                            }
                        }
                    }
                    if (index == -1)
                    {
                        index = tempData.Length;
                        length = 0;
                        rowEnd = true;
                    }
                    tempStr = tempData.Substring(start, index - start);
                    tempStr.Replace("\"\"", "\"");
                    tempData = tempData.Substring(index + length);
                    spliptStr.Add(tempStr);
                }
                table.Add(spliptStr.ToArray());
                spliptStr.Clear();
            }
            return true;
        }
        public bool SaveTable(List<string[]> table)
        {
            try
            {
                Close();
            }
            catch (Exception e)
            { }
            try
            {

                fileStream = File.Create(PathAndFileName);
                foreach (string[] r in table)
                {
                    if (!AddRow(r)) return false;
                }
                Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public void Close()
        {
            try
            {
                fileStream.Flush();
                fileStream.Close();
            }
            catch { }
        }
    }
}
