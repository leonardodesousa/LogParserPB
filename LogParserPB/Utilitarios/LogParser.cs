using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class LogParser
{
    public void ExtractSqlFromLog(string inputLogPath, string outputFilePath)
    {
        try
        {
            // Lista para armazenar as linhas de saída
            List<string> outputLines = new List<string>();
            string currentDateTime = string.Empty;

            // Expressão regular para capturar data/hora
            string dateTimePattern = @"\/\*[\s]*(\d{2}\/\d{2}\/\d{4}\s+\d{2}:\d{2})[\s]*\*\/";
            // Expressão regular para capturar instruções SQL (SELECT, INSERT, DELETE, UPDATE)
            string sqlPattern = @"\((.*?)\): (SELECT|INSERT|DELETE|UPDATE)\b.*?\(\d+\.\d+ MS";

            // Lê todas as linhas do arquivo de log
            string[] logLines = File.ReadAllLines(inputLogPath);

            foreach (string line in logLines)
            {
                // Verifica se a linha contém a data/hora
                var dateTimeMatch = Regex.Match(line, dateTimePattern);
                if (dateTimeMatch.Success)
                {
                    currentDateTime = dateTimeMatch.Groups[1].Value;
                    outputLines.Add($"\n /* {currentDateTime} */ ");
                    continue;
                }

                // Verifica se a linha contém uma instrução SQL
                var sqlMatch = Regex.Match(line, sqlPattern, RegexOptions.IgnoreCase);
                if (sqlMatch.Success)
                {
                    // Extrai a instrução SQL e indenta
                    string sqlStatement = line.Substring(line.IndexOf(':') + 2, line.LastIndexOf('(') - line.IndexOf(':') - 2).Trim();
                    outputLines.Add($"    {sqlStatement}");
                }
            }

            // Escreve as linhas no arquivo de saída
            File.WriteAllLines(outputFilePath, outputLines);
            Console.WriteLine($"Arquivo gerado com sucesso: {outputFilePath}");
            System.Windows.Forms.MessageBox.Show($"Arquivo gerado com sucesso: {outputFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao processar o arquivo: {ex.Message}");
            System.Windows.Forms.MessageBox.Show($"Erro ao processar o arquivo: {ex.Message}");
        }
    }
}