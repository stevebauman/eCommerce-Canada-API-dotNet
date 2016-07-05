namespace MonerisRisk
{
    using System;
    using System.Collections;
	public class TestRiskCheckSession
	{
	  public static void Main(string[] args)
	  {
		  /******************* REQUEST VARIABLES*******************************/

		  string host = "esqa.moneris.com";
		  string store_id = "moneris";
		  string api_token = "hurgle";

		  /****************** TRANSACTION VARIABLES *****************************/

		  string order_id; 		//will prompt user for input
          string session_id = "abc123";
		  string service_type = "session";
		  string event_type = "LOGIN";

		  Console.Write ("Please enter an order ID: ");
		  order_id = Console.ReadLine();

          SessionQuery sq = new SessionQuery(order_id, session_id, service_type);

          sq.setEventType(event_type);
          
          //sq.setPolicy("");
          //sq.setDeviceId("4EC40DE5-0770-4fa0-BE53-981C067C598D");
          sq.setAccountLogin("13195417-8CA0-46cd-960D-14C158E4DBB2");
          sq.setPasswordHash("489c830f10f7c601d30599a0deaf66e64d2aa50a");
          sq.setAccountNumber("3E17A905-AC8A-4c8d-A417-3DADA2A55220");
          sq.setAccountName("4590FCC0-DF4A-44d9-A57B-AF9DE98B84DD");
          sq.setAccountEmail("3CAE72EF-6B69-4a25-93FE-2674735E78E8@test.threatmetrix.com");
          //sq.setAccountTelephone("5556667777");
          sq.setPan("4242424242424242");
          //sq.setAccountAddressStreet1("3300 Bloor St W");
          //sq.setAccountAddressStreet2("4th Flr West Tower");
          //sq.setAccountAddressCity("Toronto");
          //sq.setAccountAddressState("Ontario");
          //sq.setAccountAddressCountry("Canada");
          //sq.setAccountAddressZip("M8X2X2");
          //sq.setShippingAddressStreet1("3300 Bloor St W");
          //sq.setShippingAddressStreet2("4th Flr West Tower");
          //sq.setShippingAddressCity("Toronto");
          //sq.setShippingAddressState("Ontario");
          //sq.setShippingAddressCountry("Canada");
          //sq.setShippingAddressZip("M8X2X2");
          //sq.setLocalAttrib1("a");
          //sq.setLocalAttrib2("b");
          //sq.setLocalAttrib3("c");
          //sq.setLocalAttrib4("d");
          //sq.setLocalAttrib5("e");
          //sq.setTransactionAmount("1.00");
          //sq.setTransactionCurrency("840");
          //set SessionAccountInfo
          sq.setTransactionCurrency("CAN");

          
          HttpsPostRequest mpgReq =
	               new HttpsPostRequest(host, store_id, api_token, sq);
	                       
	        try
	        {
                Hashtable results = new Hashtable();
                string[] rules;
	            Receipt receipt = mpgReq.GetReceipt();
	
	    		Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
	    		Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());

                results = receipt.GetResult();

                //Iterate through the response
                IDictionaryEnumerator r = results.GetEnumerator();
                while (r.MoveNext())
                {
                    Console.WriteLine(r.Key.ToString() + " = " + r.Value.ToString());
                }

                //Iterate through the rules that were fired
                rules = receipt.GetRules();

                for (int i = 0; i < rules.Length; i++)
                {
                    Console.WriteLine("RuleName = " + rules[i]);
                    Console.WriteLine("RuleCode = " + receipt.GetRuleCode(rules[i]));
                    Console.WriteLine("RuleMessageEn = " + receipt.GetRuleMessageEn(rules[i]));
                    Console.WriteLine("RuleMessageFr = " + receipt.GetRuleMessageFr(rules[i]));
                }
                
	
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	  }
				
	} // end TestRiskCheckSession
}
