using System;

namespace Moneris
{

   public class TestMCLevel23
   {
	public static void Main()
	{
	   string host = "esqa.moneris.com";
	   string store_id = "moneris";
	   string api_token = "hurgle";
	   string order_id = "PPOPOOLO";
	   string txn_number = "25972-283-1";
		    
	   string customerCode = "ACCOUNTING OPERAT";
	   double taxAmount0 = 0.98;
	   double freightAmount = 0.0;
	   string shipToPosCode = "V6Z 2V8";
	   string shipFromPosCode = "V5C 3W9";
	   double dutyAmount = 0.0;
	   string altTaxAmtInd = "Y";
	   double altTaxAmt = 0.0;
  	   string desCouCode = "CAN";
           string supData = "MASTERCARD";
           string salTaxColInd = "Y";
           
           /***************************** Level 2 Addendum **********************************/
				
	   MCLevel2Transaction level2=
	   	new MCLevel2Transaction(customerCode, taxAmount0, freightAmount, shipToPosCode, 
	   				shipFromPosCode, dutyAmount, altTaxAmtInd, 
					altTaxAmt, desCouCode, supData,salTaxColInd);
					
           /***************************** Level 3 Addendum **********************************/
					
	   MCLevel3Transaction[] level3 = new MCLevel3Transaction[2];
			
	   string[] productCode = new string[] {"OPTIBELT 4L1","OPTIBELT 4L2"};
	   string[] itemDescription=new string[] {"OPTIBELT 4L250 FHP BELT", "OPTIBELT 4L260 FHP BELT"};
	   int[] itemQuantity = new int[] {2,2};
           string[] itemUom = new string[] {"EA","EA"};
 	   double[] extItemAmount = new double[] {0.01, 0.01};
	   string[] discountInd = new string[] {"N","N"};
	   double[] discountAmount = new double[] {0.0,0.0};
	   string[] netGroIndForExtItemAmt = new string[] {"N","N"};
	   double[] taxRateApp = new double[] {0.06,0.11};
	   string[] taxTypeApp = new string[] {"",""};
	   double[] taxAmount=new double[] {0.0,0.0};
           string[] debitCreditInd=new string[] {"D","D"};
           double[] altTaxIdeAmt=new double[] {0.0,0.0};
	   
	   level3[0]=new MCLevel3Transaction(productCode[0], itemDescription[0], itemQuantity[0], 
	   				     itemUom[0], extItemAmount[0], discountInd[0], 
					     discountAmount[0],netGroIndForExtItemAmt[0], 
					     taxRateApp[0], taxTypeApp[0], taxAmount[0],
					     
	    //the other way to create a MCLevel3Transaction object
					     debitCreditInd[0], altTaxIdeAmt[0]);
	    level3[1]=new MCLevel3Transaction();
	    level3[1].ProductCode=productCode[1];
	    level3[1].ItemDescription=itemDescription[1];
	    level3[1].ItemQuantity=itemQuantity[1];
	    level3[1].ItemUom=itemUom[1];
	    level3[1].ExtItemAmount=extItemAmount[1];
	    level3[1].DiscountInd=discountInd[1];
	    level3[1].DiscountAmount=discountAmount[1];
	    level3[1].NetGroIndForExtItemAmt=netGroIndForExtItemAmt[1];
	    level3[1].TaxRateApp=taxRateApp[1];
	    level3[1].TaxTypeApp=taxTypeApp[1];
	    level3[1].TaxAmount=taxAmount[1];
	    level3[1].DebitCreditInd=debitCreditInd[1];
	    level3[1].AltTaxIdeAmt=altTaxIdeAmt[1];
	    
	    try
	    {
	    
	    /******************************** Request **********************************/
	    
		L23HttpsPostRequest request=
			new L23HttpsPostRequest(host, store_id, api_token, 
				new MCLevel23(order_id,txn_number, level2, level3));
				
	    /******************************** Response **********************************/
		
		Receipt myReceipt=request.GetReceipt();
		Console.WriteLine("CardType = " + myReceipt.GetCardType());
		Console.WriteLine("TransAmount = " + myReceipt.GetTransAmount());
		Console.WriteLine("TxnNumber = " + myReceipt.GetTxnNumber());
		Console.WriteLine("ReceiptId = " + myReceipt.GetReceiptId());
		Console.WriteLine("TransType = " + myReceipt.GetTransType());
		Console.WriteLine("ReferenceNum = " + myReceipt.GetReferenceNum());
		Console.WriteLine("ResponseCode = " + myReceipt.GetResponseCode());
		Console.WriteLine("ISO = " + myReceipt.GetISO());
		Console.WriteLine("BankTotals = " + myReceipt.GetBankTotals());
		Console.WriteLine("Message = " + myReceipt.GetMessage());
		Console.WriteLine("AuthCode = " + myReceipt.GetAuthCode());
		Console.WriteLine("Complete = " + myReceipt.GetComplete());
		Console.WriteLine("TransDate = " + myReceipt.GetTransDate());
		Console.WriteLine("TransTime = " + myReceipt.GetTransTime());
		Console.WriteLine("Ticket = " + myReceipt.GetTicket());
		Console.WriteLine("TimedOut = " + myReceipt.GetTimedOut());
		Console.WriteLine("CorporateCard = " + myReceipt.GetCorporateCard());
		Console.WriteLine("MessageId = " + myReceipt.GetMessageId());
	     }
	     catch ( Exception e )
	     {
		Console.WriteLine(e);
	     }
	  }
  }
}
