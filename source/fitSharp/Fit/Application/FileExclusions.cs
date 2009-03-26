// FitNesse.NET
// Copyright � 2008 Syterra Software Inc. This program is free software;
// you can redistribute it and/or modify it under the terms of the GNU General Public License version 2.
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

using System.Text.RegularExpressions;
using fitSharp.Fit.Application;

namespace fit {
    public class FileExclusions: ConfigurationList<string> {
        public override string Parse(string theValue) { return theValue; }

        public override ConfigurationList<string> Make() { return new FileExclusions(); }

	    public bool IsExcluded(string theName) {
	        foreach (string pattern in myList) {
	            if (Regex.IsMatch(theName, pattern)) return true;
	        }
	        return false;
	    }
    }
}