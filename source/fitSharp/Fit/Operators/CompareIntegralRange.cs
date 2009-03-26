// Modified or written by Object Mentor, Inc. for inclusion with FitNesse.
// Copyright (c) 2002 Cunningham & Cunningham, Inc.
// Released under the terms of the GNU General Public License version 2 or later.

using System;
using System.Text.RegularExpressions;
using fitSharp.Fit.Model;
using fitSharp.Machine.Engine;
using fitSharp.Machine.Model;

namespace fitSharp.Fit.Operators {
    public class CompareIntegralRange : CompareOperator<Cell> {
        private static readonly Regex matchExpression = new Regex("^-?[0-9]+\\.\\.-?[0-9]+$");

        public bool TryCompare(Processor<Cell> processor, TypedValue instance, Tree<Cell> parameters, ref bool result) {
            if (instance.Type != typeof (int) || !matchExpression.IsMatch(parameters.Value.Text)) return false;
            string[] parts = parameters.Value.Text.Split('.');
            result = IsInRange((int)instance.Value, LowEnd(parts), HighEnd(parts));
            return true;
        }

        private static int HighEnd(string[] args) {
            return Convert.ToInt32(args[args.Length - 1]);
        }

        private static int LowEnd(string[] args) {
            return Convert.ToInt32(args[0]);
        }

        private static bool IsInRange(int actual, int low, int high) {
            return actual >= low && actual <= high;
        }
    }
}