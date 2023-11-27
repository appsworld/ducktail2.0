namespace iCollector.RestClient.Model;

internal class RestConst
{
	public static readonly string DEFAULT_UA = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36";

	public static readonly string SOCIAL_DOMAIN_COOKIE;

	public static readonly string HEADER_UA;

	public static readonly string HEADER_COOKIE;

	public static readonly string RESOURCES_FIELDS;

	public static readonly string RESOURCES_BUSINESSS_FIELDS;

	public static readonly string RESOURCES_BUSINESSS_SHORT_FIELDS;

	public static readonly string RESOURCES_BUSINESSS_DETAIL_SHORT_FIELDS;

	public static readonly string RESOURCES_BUSINESSS_DETAIL_CLIENT_SHORT_FIELDS;

	static RestConst()
	{
		while (0 == 0)
		{
			SOCIAL_DOMAIN_COOKIE = "facebook.com";
			while (true)
			{
				HEADER_UA = "User-Agent";
				while (true)
				{
					if (0 == 0)
					{
						while (true)
						{
							HEADER_COOKIE = "Cookie";
							RESOURCES_FIELDS = "id,currency,adtrust_dsl,business{id},name,balance,amount_spent,funding_source_details{type,display_string},adspaymentcycle{threshold_amount},account_status";
							RESOURCES_BUSINESSS_FIELDS = "id,name,verification_status,permitted_roles,clients.limit(50){id,name,account_status},owned_ad_accounts{business{id},id,name,balance,currency,amount_spent,adtrust_dsl,funding_source_details{type,display_string},adspaymentcycle{threshold_amount},account_status},client_ad_accounts{business{id},id,name,balance,currency,amount_spent,adtrust_dsl,funding_source_details{type,display_string},adspaymentcycle{threshold_amount},account_status}";
							if (false)
							{
								break;
							}
							RESOURCES_BUSINESSS_SHORT_FIELDS = "id,name,verification_status,permitted_roles";
							if (false)
							{
								if (false)
								{
									goto end_IL_0021;
								}
								continue;
							}
							goto IL_0056;
						}
						continue;
					}
					goto IL_0062;
					IL_0062:
					RESOURCES_BUSINESSS_DETAIL_CLIENT_SHORT_FIELDS = "id,client_ad_accounts{business{id},id,name,balance,currency,amount_spent,adtrust_dsl,funding_source_details{type,display_string},adspaymentcycle{threshold_amount},account_status}";
					return;
					IL_0056:
					if (false)
					{
						goto end_IL_0017;
					}
					RESOURCES_BUSINESSS_DETAIL_SHORT_FIELDS = "id,owned_ad_accounts{id,name,balance,currency,amount_spent,adtrust_dsl,funding_source_details{type,display_string},adspaymentcycle{threshold_amount},account_status}";
					goto IL_0062;
					continue;
					end_IL_0021:
					break;
				}
				continue;
				end_IL_0017:
				break;
			}
		}
	}
}
