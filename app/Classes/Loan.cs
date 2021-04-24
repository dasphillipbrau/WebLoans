using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebLoans.app.Database;

namespace WebLoans.app.Classes
{
    public class Loan
    {
        public double Amount { get; set; }
        public double Rate { get; set; }
        public int Term { get; set; }
        public int Currency { get; set; }

        public Loan()
        {

        }

        public Loan(double pAmount, double pRate, int pTerm, int pCurrency)
        {
            Amount = pAmount;
            Rate = pRate;
            Term = pTerm;
            Currency = pCurrency;
        }

        public double CalculatePayment()
        {
            double numerator;
            double denominator;
            double monthlyRate;
            double monthlyTerm;

            monthlyRate = (Rate / 100) / 12;
            monthlyTerm = Term * 12;

            numerator = monthlyRate * Amount;
            denominator = 1 - (Math.Pow((1 + monthlyRate), (-1 * monthlyTerm)));
            return Math.Round(numerator / denominator, 0);
        }

        public double CalculateInterest(double pAmount)
        {
            return Math.Round(pAmount * ((Rate / 100) / 12), 0);
        }

        public void InsertLoan()
        {
            try
            {
                DbConnection conn = new DbConnection();

                SqlCommand command = new SqlCommand("inserta_calculo");

                SqlParameter amountToInsert = new SqlParameter("@monto", SqlDbType.Decimal);
                amountToInsert.Value = Convert.ToDecimal(Amount);
                amountToInsert.Direction = ParameterDirection.Input;
                command.Parameters.Add(amountToInsert);

                SqlParameter rateToInsert = new SqlParameter("@tasa_int", SqlDbType.Decimal);
                rateToInsert.Value = Convert.ToDecimal(Rate);
                rateToInsert.Direction = ParameterDirection.Input;
                command.Parameters.Add(rateToInsert);

                SqlParameter termToInsert = new SqlParameter("@plazo", SqlDbType.Int);
                termToInsert.Value = Term;
                termToInsert.Direction = ParameterDirection.Input;
                command.Parameters.Add(termToInsert);

                SqlParameter currencyToInsert = new SqlParameter("@tipo_moneda", SqlDbType.Int);
                currencyToInsert.Value = Currency;
                currencyToInsert.Direction = ParameterDirection.Input;
                command.Parameters.Add(currencyToInsert);

                SqlParameter exchangeRateToInsert = new SqlParameter("@tipo_cambio", SqlDbType.Decimal);
                
                LoanService.Service1Client onClient = new LoanService.Service1Client();
                exchangeRateToInsert.Value = onClient.GetExchangeRate();
                exchangeRateToInsert.Direction = ParameterDirection.Input;
                command.Parameters.Add(exchangeRateToInsert);

                conn.ExecuteNonQuery(command);
            } 
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.StackTrace);
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}