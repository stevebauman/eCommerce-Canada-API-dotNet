namespace Moneris
{
    using System;
    public class TestResCardVerificationCC
    {
        public static void Main(string[] args)
        {
            string host = "esqa.moneris.com";
            string store_id = "store5";
            string api_token = "yesguy";
            string data_key = "abcdefghijklmnop";
            string order_id = "Test_P_033333";
            string cust_id = "Customer1";
            string crypt = "7";

            /*************** Address Verification Service **********************/

            AvsInfo avsCheck = new AvsInfo();

            avsCheck.SetAvsStreetNumber("212");
            avsCheck.SetAvsStreetName("Payton Street");
            avsCheck.SetAvsZipCode("M1M1M1");

            ResCardVerificationCC rescardverify = new ResCardVerificationCC(data_key, order_id, cust_id, crypt);
            rescardverify.SetAvsInfo(avsCheck);

            /****************** Card Validation Digits *************************/

            CvdInfo cvdCheck = new CvdInfo();
            cvdCheck.SetCvdIndicator("1");
            cvdCheck.SetCvdValue("099");

            rescardverify.SetCvdInfo(cvdCheck);
            HttpsPostRequest mpgReq =
                  new HttpsPostRequest(host, store_id, api_token, rescardverify);

            try
            {
                Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("CardType = " + receipt.GetCardType());
                Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
                Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
                Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
                Console.WriteLine("TransType = " + receipt.GetTransType());
                Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
                Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                Console.WriteLine("ISO = " + receipt.GetISO());
                Console.WriteLine("BankTotals = " + receipt.GetBankTotals());
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("Ticket = " + receipt.GetTicket());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("IsVisaDebit = " + receipt.GetIsVisaDebit());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    } // end TestResCardVerificationCC
}
