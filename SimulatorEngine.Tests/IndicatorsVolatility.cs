﻿//==============================================================================
// Project:     TuringTrader: SimulatorEngine.Tests
// Name:        IndicatorsVolatility
// Description: unit test for volatility indicators
// History:     2019ii21, FUB, created
//------------------------------------------------------------------------------
// Copyright:   (c) 2017-2018, Bertram Solutions LLC
//              http://www.bertram.solutions
// License:     This code is licensed under the term of the
//              GNU Affero General Public License as published by 
//              the Free Software Foundation, either version 3 of 
//              the License, or (at your option) any later version.
//              see: https://www.gnu.org/licenses/agpl-3.0.en.html
//==============================================================================

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TuringTrader.Simulator;

namespace SimulatorEngine.Tests
{
    [TestClass]
    public class IndicatorsVolatility
    {
        #region public void Test_StandardDeviation()
        [TestMethod]
        public void Test_StandardDeviation()
        {
            double[,] testVectors =
            {
                { 100.00000, 0.00000, 0.00000, 0.00000, 0.00000, },
                { 105.00000, 2.50000, 0.00000, 0.00000, 0.00000, },
                { 102.50000, 2.39357, 2.50000, 0.00000, 0.00000, },
                { 107.50000, 3.22749, 2.39357, 2.50000, 0.00000, },
                { 105.00000, 2.04124, 3.22749, 2.39357, 2.50000, },
                { 110.00000, 3.22749, 2.04124, 3.22749, 2.39357, },
                { 107.50000, 2.04124, 3.22749, 2.04124, 3.22749, },
                { 112.50000, 3.22749, 2.04124, 3.22749, 2.04124, },
                { 110.00000, 2.04124, 3.22749, 2.04124, 3.22749, },
                { 115.00000, 3.22749, 2.04124, 3.22749, 2.04124, },
            };

            TimeSeries<double> stimulus = new TimeSeries<double>();

            for (int row = 0; row <= testVectors.GetUpperBound(0); row++)
            {
                stimulus.Value = testVectors[row, 0];
                ITimeSeries<double> response = stimulus.StandardDeviation(4);
                //Output.Write("{{ {0:F5}, ", testVectors[row, 0]);

                for (int col = 1; col <= testVectors.GetUpperBound(1); col++)
                {
                    int t = col - 1;
                    double responseValue = response[t];
                    double expectedValue = testVectors[row, col];
                    //Output.Write("{0:F5}, ", responseValue);

                    Assert.IsTrue(Math.Abs(responseValue - expectedValue) < 1e-5);
                }
                //Output.WriteLine("},");
            }
        }
        #endregion
        #region public void Test_FastStandardDeviation()
        [TestMethod]
        public void Test_FastStandardDeviation()
        {
            double[,] testVectors =
            {
                { 100.00000, 0.00000, 0.00000, 0.00000, 0.00000, },
                { 105.00000, 2.44949, 0.00000, 0.00000, 0.00000, },
                { 102.50000, 1.91311, 2.44949, 0.00000, 0.00000, },
                { 107.50000, 2.98958, 1.91311, 2.44949, 0.00000, },
                { 105.00000, 2.33956, 2.98958, 1.91311, 2.44949, },
                { 110.00000, 3.20987, 2.33956, 2.98958, 1.91311, },
                { 107.50000, 2.51299, 3.20987, 2.33956, 2.98958, },
                { 112.50000, 3.30295, 2.51299, 3.20987, 2.33956, },
                { 110.00000, 2.58598, 3.30295, 2.51299, 3.20987, },
                { 115.00000, 3.34207, 2.58598, 3.30295, 2.51299, },
            };

            TimeSeries<double> stimulus = new TimeSeries<double>();

            for (int row = 0; row <= testVectors.GetUpperBound(0); row++)
            {
                stimulus.Value = testVectors[row, 0];
                ITimeSeries<double> response = stimulus.FastStandardDeviation(4);
                //Output.Write("{{ {0:F5}, ", testVectors[row, 0]);

                for (int col = 1; col <= testVectors.GetUpperBound(1); col++)
                {
                    int t = col - 1;
                    double responseValue = response[t];
                    double expectedValue = testVectors[row, col];
                    //Output.Write("{0:F5}, ", responseValue);

                    Assert.IsTrue(Math.Abs(responseValue - expectedValue) < 1e-5);
                }
                //Output.WriteLine("},");
            }
        }
        #endregion

        #region public void Test_SemiDeviation()
        [TestMethod]
        public void Test_SemiDeviation()
        {
            double[,] testVectorsUpside =
            {
                { 105.00000, 0.00000, 0.00000, 0.00000, 0.00000, },
                { 102.50000, 0.00000, 0.00000, 0.00000, 0.00000, },
                { 107.50000, 1.71464, 0.00000, 0.00000, 0.00000, },
                { 105.00000, 1.32816, 1.71464, 0.00000, 0.00000, },
                { 110.00000, 2.54877, 1.32816, 1.71464, 0.00000, },
                { 107.50000, 1.98196, 2.54877, 1.32816, 1.71464, },
                { 112.50000, 2.98001, 1.98196, 2.54877, 1.32816, },
                { 110.00000, 2.32873, 2.98001, 1.98196, 2.54877, },
                { 115.00000, 3.19256, 2.32873, 2.98001, 1.98196, },
            };
            double[,] testVectorsDownside =
            {
                { 105.00000, 0.00000, 0.00000, 0.00000, 0.00000, },
                { 102.50000, 1.22474, 0.00000, 0.00000, 0.00000, },
                { 107.50000, 0.94868, 1.22474, 0.00000, 0.00000, },
                { 105.00000, 0.76053, 0.94868, 1.22474, 0.00000, },
                { 110.00000, 0.58910, 0.76053, 0.94868, 1.22474, },
                { 107.50000, 0.45632, 0.58910, 0.76053, 0.94868, },
                { 112.50000, 0.35346, 0.45632, 0.58910, 0.76053, },
                { 110.00000, 0.27379, 0.35346, 0.45632, 0.58910, },
                { 115.00000, 0.21208, 0.27379, 0.35346, 0.45632, },
            };

            TimeSeries<double> stimulus = new TimeSeries<double>();

            for (int row = 0; row <= testVectorsUpside.GetUpperBound(0); row++)
            {
                stimulus.Value = testVectorsUpside[row, 0];
                ITimeSeries<double> responseUpside = stimulus.SemiDeviation(4).Upside;
                ITimeSeries<double> responseDownside = stimulus.SemiDeviation(4).Downside;
                //Output.Write("{{ {0:F5}, ", testVectorsUpside[row, 0]);
                //Output.Write("{{ {0:F5}, ", testVectorsDownside[row, 0]);

                for (int col = 1; col <= testVectorsUpside.GetUpperBound(1); col++)
                {
                    int t = col - 1;

                    double responseValueUpside = responseUpside[t];
                    double expectedValueUpside = testVectorsUpside[row, col];
                    //Output.Write("{0:F5}, ", responseValueUpside);
                    Assert.IsTrue(Math.Abs(responseValueUpside - expectedValueUpside) < 1e-5);

                    double responseValueDownside = responseDownside[t];
                    double expectedValueDownside = testVectorsDownside[row, col];
                    //Output.Write("{0:F5}, ", responseValueDownside);
                    Assert.IsTrue(Math.Abs(responseValueDownside - expectedValueDownside) < 1e-5);
                }
                //Output.WriteLine("},");
            }
        }
        #endregion
    }
}

//==============================================================================
// end of file