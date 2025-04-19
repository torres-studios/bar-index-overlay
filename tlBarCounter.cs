#region Using declarations
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.SuperDom;
using NinjaTrader.Gui.Tools;
using NinjaTrader.Data;
using NinjaTrader.NinjaScript;
using NinjaTrader.Core.FloatingPoint;
using NinjaTrader.NinjaScript.DrawingTools;
#endregion

//This namespace holds Indicators in this folder and is required. Do not change it. 
namespace NinjaTrader.NinjaScript.Indicators.TorresLabs.BarCounter
{
    public class tlBarCounter : Indicator
    {
        protected override void OnStateChange()
        {
            if (State == State.SetDefaults)
            {
                Description = @"Adds labels to each bar on a chart and optionally displays the total count of bars on the screen. For help when testing.";
                Name = "tlBarCounter";
                Calculate = Calculate.OnBarClose;
                IsOverlay = true;
                DisplayInDataBox = true;
                DrawOnPricePanel = true;
                DrawHorizontalGridLines = true;
                DrawVerticalGridLines = true;
                PaintPriceMarkers = true;
                ScaleJustification = NinjaTrader.Gui.Chart.ScaleJustification.Right;
                //Disable this property if your indicator requires custom values that cumulate with each new market data event. 
                //See Help Guide for additional information.
                IsSuspendedWhileInactive = true;

                // Custom indicator properties default values
                ShowTotalBarCount = true;
            }
            else if (State == State.Configure)
            {
            }
        }

        protected override void OnBarUpdate()
        {
            // Add the currentBar index to each bar for testing
            Draw.Text(
                this,
                "barindex_" + CurrentBar,
                CurrentBar.ToString(),
                0,
                High[0]);

            if (ShowTotalBarCount && CurrentBar == ChartBars.Count - 2)
                Draw.TextFixed(
                    this,
                    "bartotalcount",
                    "Bar count: " + ChartBars.Count.ToString(),
                    TextPosition.BottomRight);
        }

        [NinjaScriptProperty]
        [Display(Name = "ShowTotalBarCount", Description = "Determines whether the total bar count should appear on the chart.", Order = 1, GroupName = "Indicators Parameters")]
        public bool ShowTotalBarCount
        { get; set; }
    }
}

#region NinjaScript generated code. Neither change nor remove.

namespace NinjaTrader.NinjaScript.Indicators
{
    public partial class Indicator : NinjaTrader.Gui.NinjaScript.IndicatorRenderBase
    {
        private TorresLabs.BarCounter.tlBarCounter[] cachetlBarCounter;
        public TorresLabs.BarCounter.tlBarCounter tlBarCounter(bool showTotalBarCount)
        {
            return tlBarCounter(Input, showTotalBarCount);
        }

        public TorresLabs.BarCounter.tlBarCounter tlBarCounter(ISeries<double> input, bool showTotalBarCount)
        {
            if (cachetlBarCounter != null)
                for (int idx = 0; idx < cachetlBarCounter.Length; idx++)
                    if (cachetlBarCounter[idx] != null && cachetlBarCounter[idx].ShowTotalBarCount == showTotalBarCount && cachetlBarCounter[idx].EqualsInput(input))
                        return cachetlBarCounter[idx];
            return CacheIndicator<TorresLabs.BarCounter.tlBarCounter>(new TorresLabs.BarCounter.tlBarCounter() { ShowTotalBarCount = showTotalBarCount }, input, ref cachetlBarCounter);
        }
    }
}

namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
    public partial class MarketAnalyzerColumn : MarketAnalyzerColumnBase
    {
        public Indicators.TorresLabs.BarCounter.tlBarCounter tlBarCounter(bool showTotalBarCount)
        {
            return indicator.tlBarCounter(Input, showTotalBarCount);
        }

        public Indicators.TorresLabs.BarCounter.tlBarCounter tlBarCounter(ISeries<double> input, bool showTotalBarCount)
        {
            return indicator.tlBarCounter(input, showTotalBarCount);
        }
    }
}

namespace NinjaTrader.NinjaScript.Strategies
{
    public partial class Strategy : NinjaTrader.Gui.NinjaScript.StrategyRenderBase
    {
        public Indicators.TorresLabs.BarCounter.tlBarCounter tlBarCounter(bool showTotalBarCount)
        {
            return indicator.tlBarCounter(Input, showTotalBarCount);
        }

        public Indicators.TorresLabs.BarCounter.tlBarCounter tlBarCounter(ISeries<double> input, bool showTotalBarCount)
        {
            return indicator.tlBarCounter(input, showTotalBarCount);
        }
    }
}

#endregion
