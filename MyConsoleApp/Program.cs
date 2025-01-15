using System;

namespace MyConsoleApp
{
    class Program
    {
        //declare constant file paths
        const string readFile = "/workspace/c-sharpin/MyConsoleApp/WeeklySales.CSV";
        const string writeFile = "/workspace/c-sharpin/MyConsoleApp/reportFile.txt";

        //initialise & size arrays
        static string[] departments = {"Hardware", "Kitchen Goods", "Food", "Clothes" };

        static double[] deptTotalSales = new double[4];
        static double[] deptNumberSalesPeople = new double[4];
        static double[] deptAverageSales = new double[4];
        static double[] deptHighestSales = new double[4];
        static string[] deptBestSalesPerson = new string[4];


        static void Main(string[] args)
        {
            string[] dataLines = File.ReadAllLines(readFile);

            deptTotalSales = GetTotalSales(dataLines, deptTotalSales);
            deptNumberSalesPeople = GetNumberSalesPeople(dataLines, deptNumberSalesPeople);
            deptAverageSales = GetAverageSales(deptAverageSales, deptTotalSales, deptNumberSalesPeople);
            deptBestSalesPerson = GetBestSalesPerson(dataLines, deptHighestSales, deptBestSalesPerson);

            for (int i=0; i < deptBestSalesPerson.Length; i++){
                Console.WriteLine(deptBestSalesPerson[i]);
            }
        }

    //find total values in line
    static double GetTotalValue(string[] splitLine, double totalValue){

        for (int j=2; j < splitLine.Length; j++){
            totalValue += Convert.ToDouble(splitLine[j]);
        }
        
        return totalValue;
    }

    // get total sales  for each department
    static double[] GetTotalSales(string[] dataLines, double[] deptTotalSales){
        for (int i=1; i < dataLines.Length; i++){
            string[] splitLine = dataLines[i].Split(",");

            if (splitLine[1] == "Hardware"){
                deptTotalSales[0] = GetTotalValue(splitLine, deptTotalSales[0]);
            }

            else if (splitLine[1] == "Kitchen Goods"){
                deptTotalSales[1] = GetTotalValue(splitLine, deptTotalSales[1]);
            }

            else if (splitLine[1] == "Food"){
                deptTotalSales[2] = GetTotalValue(splitLine, deptTotalSales[2]);
            }

            else {
                deptTotalSales[3] = GetTotalValue(splitLine, deptTotalSales[3]);
            }
        }

        return deptTotalSales;
    }

    //find no of sales people per department
    static double[] GetNumberSalesPeople(string[] dataLines, double[] deptNumberSalesPeople){

        for (int i=1; i < dataLines.Length; i++){
            string[] splitLine = dataLines[i].Split(",");

            if (splitLine[1] == "Hardware"){
                deptNumberSalesPeople[0] +=1;
            }

            else if (splitLine[1] == "Kitchen Goods"){
                deptNumberSalesPeople[1] +=1;
            }

            else if (splitLine[1] == "Food"){
                deptNumberSalesPeople[2] +=1;
            }

            else {
                deptNumberSalesPeople[3] +=1;
            }
        }

        return deptNumberSalesPeople;
    }

    //find average sales for each department
    static double[] GetAverageSales(double[] deptAverageSales, double[] deptTotalSales, double[] deptNumberSalesPeople){
        for (int i=0; i< deptAverageSales.Length; i++){
            deptAverageSales[i] = deptTotalSales[i] / deptNumberSalesPeople[i];
        }

        return deptAverageSales;
    }

    //find best sales person
    static string[] GetBestSalesPerson(string[] dataLines, double[] deptHighestSales, string[] deptBestSalesPerson){

        for (int i=1; i < dataLines.Length; i++){
            string[] splitLine = dataLines[i].Split(",");

            if (splitLine[1] == "Hardware"){
                double totalSales = GetTotalValue(splitLine, deptHighestSales[0]);
                if (totalSales > deptHighestSales[0]){
                    deptHighestSales[0] = totalSales;
                    deptBestSalesPerson[0] = splitLine[0];
                }
            }

            else if (splitLine[1] == "Kitchen Goods"){
                double totalSales = GetTotalValue(splitLine, deptHighestSales[1]);
                if (totalSales > deptHighestSales[1]){
                    deptHighestSales[1] = totalSales;
                    deptBestSalesPerson[1] = splitLine[0];
                }
            }

            else if (splitLine[1] == "Food"){
                double totalSales = GetTotalValue(splitLine, deptHighestSales[2]);
                if (totalSales > deptHighestSales[2]){
                    deptHighestSales[2] = totalSales;
                    deptBestSalesPerson[2] = splitLine[0];
                }
            }

            else {
                double totalSales = GetTotalValue(splitLine, deptHighestSales[3]);
                if (totalSales > deptHighestSales[3]){
                    deptHighestSales[3] = totalSales;
                    deptBestSalesPerson[3] = splitLine[0];
                }
            }
        }

        return deptBestSalesPerson;

    }




    }
}
