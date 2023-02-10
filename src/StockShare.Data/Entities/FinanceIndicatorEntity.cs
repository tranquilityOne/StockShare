using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockShare.Data.Entities
{
    /// <summary>
    /// 财务指标数据
    /// </summary>
    [Table("Daily_BJS")]
    public class FinanceIndicatorEntity : EntityBase
    {
        /// <summary>
        /// Ts 代码
        /// </summary>
        [StringLength(30)]
        public string Ts_Code { get; set; } = default!;

        /// <summary>
        /// 公告日期
        /// </summary>
        [StringLength(30)]
        public string Ann_date { get; set; } = default!;

        /// <summary>
        ///  报告期
        /// </summary>
        [StringLength(30)]
        public string End_date { get; set; } = default!;

        /// <summary>
        /// 非经常性损益
        /// </summary>
        public decimal Extra_item { get; set; } = default!;

        /// <summary>
        /// 扣除非经常性损益后的净利润（扣非净利润）
        /// </summary>
        public decimal Profit_dedt { get; set; } = default!;

        /// <summary>
        /// 毛利
        /// </summary>
        public decimal Gross_margin { get; set; } = default!;

        /// <summary>
        /// 流动比率 (流动资产合计/流动负债合计)
        /// </summary>
        public decimal Current_ratio { get; set; } = default;

        /// <summary>
        /// 速动比率 (流动资产-存货等/流动负债合计)
        /// </summary>
        public decimal Quick_ratio { get; set; }

        /// <summary>
        /// 存货周转率 (存货周转率又名库存周转率，是企业一定时期营业成本（销货成本）与平均存货余额的比率)
        /// </summary>
        public decimal Inv_turn { get; set; }

        /// <summary>
        /// 应收账款周转率 (应收账款周转率越高，说明其收回越快)
        /// </summary>
        public decimal Ar_turn { get; set; }

        /// <summary>
        /// 经营活动净收益
        /// </summary>
        public decimal Op_income { get; set; }

        /// <summary>
        /// 价值变动净收益
        /// </summary>
        public decimal Valuechange_income { get; set; }

        /// <summary>
        /// 利息费用
        /// </summary>
        public decimal Interst_income { get; set; }

        /// <summary>
        /// 折旧与摊销
        /// </summary>
        public decimal Daa { get; set; }

        /// <summary>
        /// 息税前利润 (支付利息和所得税之前的利润)
        /// </summary>
        public decimal Ebit { get; set; }

        /// <summary>
        /// 息税折旧摊销前利润 (扣除利息、所得税、折旧、摊销之前的利润)
        /// </summary>
        public decimal EbitDa { get; set; }

        /// <summary>
        /// 企业自由现金流量 (税后净营业利润-净投资)
        /// </summary>
        public decimal Fcff { get; set; }

        /// <summary>
        /// 无息流动负债
        /// </summary>
        public decimal Current_exint { get; set; }

        /// <summary>
        /// 无息非流动负债
        /// </summary>
        public decimal Noncurrent_exint { get; set; }

        /// <summary>
        /// 带息债务
        /// </summary>
        public decimal Interestdebt { get; set; }

        /// <summary>
        /// 净债务
        /// </summary>
        public decimal Netdebt { get; set; }

        /// <summary>
        /// 有形资产
        /// </summary>
        public decimal Tangible_asset { get; set; }

        /// <summary>
        /// 留存收益
        /// </summary>
        public decimal Retained_earnings { get; set; }

        /// <summary>
        /// 每股净资产
        /// </summary>
        public decimal Bps { get; set; }

        /// <summary>
        /// 销售净利率
        /// 营业收入的范围比销售收入的范围大，营业收入是指单位从事经营活动获得的收入，
        /// 包括主营业务收入和其他业务收入，从性质上讲包括销售货物和提供服务，
        /// 销售收入主要指从事货物销售获得的收入.
        /// </summary>
        public decimal Netprofit_margin { get; set; }

        /// <summary>
        /// 销售毛利率
        /// </summary>
        public decimal Grossprofit_margin { get; set; }

        /// <summary>
        /// 销售成本率
        /// </summary>
        public decimal Cogs_of_sales { get; set; }

        /// <summary>
        /// 销售期间费用率
        /// </summary>
        public decimal Expense_of_sales { get; set; }

        /// <summary>
        /// 净资产收益率
        /// </summary>
        public decimal Roe { get; set; }

        /// <summary>
        /// 加权平均净资产收益率
        /// </summary>
        public decimal Roe_waa { get; set; }

        /// <summary>
        /// 净资产收益率(扣除非经常损益)
        /// </summary>
        public decimal Roe_dt { get; set; }

        /// <summary>
        /// 年化净资产收益率
        /// </summary>
        public decimal Roe_yearly { get; set; }

        /// <summary>
        /// 资产负债率
        /// </summary>
        public decimal Debt_to_assets { get; set; }
    }
}