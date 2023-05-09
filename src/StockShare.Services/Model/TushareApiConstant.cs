using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShare.Services.Model
{
    /// <summary>
    /// TushareApiConstant
    /// </summary>
    public class TushareApiConstant
    {
        /// <summary>
        /// Stock_Basic_Fields
        /// </summary>
        public const string Stock_Basic_Fields = "ts_code,symbol,name,area,industry,fullname,enname,cnspell,market,list_status,list_date,delist_date,is_hs";

        /// <summary>
        /// Stock_Basic_Api
        /// </summary>
        public const string Stock_Basic_Api = "stock_basic";

        /// <summary>
        /// https://tushare.pro/document/2?doc_id=27
        /// </summary>
        public const string Daily_Api = "daily";

        /// <summary>
        /// Daily_Api_Fields
        /// </summary>
        public const string Daily_Api_Fields = "ts_code,trade_date,open,high,low,close,pre_close,change,pct_chg,vol,amount";

        /// <summary>
        /// https://tushare.pro/document/2?doc_id=28
        /// </summary>
        public const string Adj_Factor_Api = "adj_factor";

        /// <summary>
        /// Adj_Factor_Fields
        /// </summary>
        public const string Adj_Factor_Api_Fields = "ts_code,trade_date,adj_factor";

        /// <summary>
        /// https://tushare.pro/document/2?doc_id=32
        /// </summary>
        public const string Daily_Basic_Api = "daily_basic";

        /// <summary>s
        /// Daily_Basic_Fields
        /// </summary>
        public const string Daily_Basic_Api_Fields = @"ts_code,trade_date,turnover_rate,turnover_rate_f,volume_ratio,pe,pe_ttm,
pb,ps,ps_ttm,dv_ratio,dv_ttm,total_share,float_share,free_share,total_mv,circ_mv";

        /// <summary>
        /// https://tushare.pro/document/2?doc_id=183
        /// </summary>
        public const string Stk_limit_Api = "stk_limit";

        /// <summary>
        /// Stk_limit_Api_Fields
        /// </summary>
        public const string Stk_limit_Api_Fields = "trade_date,ts_code,pre_close,up_limit,down_limit";

        /// <summary>
        /// https://tushare.pro/document/2?doc_id=79
        /// </summary>
        public const string Fina_indicator_Api = "fina_indicator";

        /// <summary>
        /// Fina_indicator_Api_Fields
        /// </summary>
        public const string Fina_indicator_Api_Fields = @"ts_code,ann_date,end_date,extra_item,profit_dedt,gross_margin,op_income
,valuechange_income,interst_income,daa,ebit,ebitda,fcff,current_exint,noncurrent_exint,interestdebt,netdebt,tangible_asset,invest_capital
,retained_earnings,bps,netprofit_margin,grossprofit_margin,cogs_of_sales,expense_of_sales,roe,roe_waa,roe_dt,roe_yearly,debt_to_assets,rd_exp";
    }
}
