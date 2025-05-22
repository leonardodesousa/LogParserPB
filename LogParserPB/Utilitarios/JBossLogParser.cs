using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

// Classe estática para métodos de extensão
public static class StringExtensions
{
    public static string ReplaceFirst(this string text, string search, string replace)
    {
        int pos = text.IndexOf(search);
        if (pos < 0)
            return text;
        return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
    }
}

// Classe não estática
public class JBossLogParser
{
    public void ExtractSqlFromJBossLog(string inputLogPath, string outputFilePath)
    {
        try
        {
            List<string> outputLines = new List<string>();
            List<string> traceParams = new List<string>();
            string currentDateTime = string.Empty;
            string currentThread = string.Empty;

            string dateTimePattern = @"^(\d{2}:\d{2}:\d{2},\d{3})\s+(DEBUG|ERROR|WARN)\s+\[.*?\]\s+\((.*?)\)";
            string sqlPattern = @"DEBUG\s+\[org\.hibernate\.SQL\]\s+\((.*?)\)\s+(select|insert|update|delete)\s+.*$";
            string tracePattern = @"TRACE\s+\[org\.hibernate\.type\.descriptor\.sql\.BasicBinder\]\s+\((.*?)\)\s+binding parameter \[(\d+)\]\s+as\s+\[(.*?)\]\s+-\s+\[(.*?)\]";
            string errorPattern = @"ERROR\s+\[(org\.hibernate\.engine\.jdbc\.spi\.SqlExceptionHelper|stderr)\]\s+\((.*?)\)\s+(.*)";

            string[] logLines = File.ReadAllLines(inputLogPath);

            foreach (string line in logLines)
            {
                var dateTimeMatch = Regex.Match(line, dateTimePattern);
                if (dateTimeMatch.Success)
                {
                    currentDateTime = dateTimeMatch.Groups[1].Value;
                    currentThread = dateTimeMatch.Groups[3].Value;
                }

                var errorMatch = Regex.Match(line, errorPattern);
                if (errorMatch.Success && errorMatch.Groups[1].Value == "org.hibernate.engine.jdbc.spi.SqlExceptionHelper")
                {
                    outputLines.Add($"/* {currentDateTime} [ERROR] */");
                    outputLines.Add($"    {errorMatch.Groups[3].Value}");
                    continue;
                }

                var sqlMatch = Regex.Match(line, sqlPattern, RegexOptions.IgnoreCase);
                if (sqlMatch.Success && sqlMatch.Groups[1].Value == currentThread)
                {
                    string sqlStatement = sqlMatch.Groups[0].Value.Substring(sqlMatch.Groups[0].Value.IndexOf(sqlMatch.Groups[2].Value)).Trim();
                    traceParams.Clear();
                    outputLines.Add($"/* {currentDateTime} */");
                    outputLines.Add($"    {sqlStatement}");
                    continue;
                }

                var traceMatch = Regex.Match(line, tracePattern);
                if (traceMatch.Success && traceMatch.Groups[1].Value == currentThread)
                {
                    string paramIndex = traceMatch.Groups[2].Value;
                    string paramType = traceMatch.Groups[3].Value;
                    string paramValue = traceMatch.Groups[4].Value;

                    if (paramType.Contains("VARCHAR") || paramType.Contains("CHAR"))
                    {
                        paramValue = $"'{paramValue}'";
                    }
                    else if (paramType.Contains("TIMESTAMP"))
                    {
                        paramValue = $"'{paramValue}'";
                    }
                    traceParams.Add(paramValue);
                    continue;
                }

                if (traceParams.Count > 0 && outputLines.Count > 0 && outputLines.Last().StartsWith("    "))
                {
                    string lastSql = outputLines.Last();
                    int paramIndex = 0;
                    while (lastSql.Contains("?") && paramIndex < traceParams.Count)
                    {
                        lastSql = lastSql.ReplaceFirst("?", traceParams[paramIndex]);
                        paramIndex++;
                    }
                    outputLines[outputLines.Count - 1] = lastSql;
                }
            }

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

// Exemplo de classe com método não estático que cria uma instância de JBossLogParser
public class LogProcessor
{
    public void ProcessLogFile(string inputLogPath, string outputFilePath)
    {
        // Cria uma instância de JBossLogParser
        JBossLogParser parser = new JBossLogParser();

        // Chama o método usando a instância
        parser.ExtractSqlFromJBossLog(inputLogPath, outputFilePath);

        Console.WriteLine("Processamento do log concluído.");
    }
}