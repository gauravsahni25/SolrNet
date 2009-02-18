﻿#region license
// Copyright (c) 2007-2009 Mauricio Scheffer
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System.Collections.Generic;
using SolrNet.Utils;

namespace SolrNet {
    /// <summary>
    /// Queries a field for a list of possible values
    /// </summary>
    public class SolrQueryInList : ISolrQuery {
        private readonly string q;

        public SolrQueryInList(string fieldName, IEnumerable<string> list) {
            q = "(" + Func.Join(" OR ", Func.Select(list, l => new SolrQueryByField(fieldName, l).Query)) + ")";
        }

        public SolrQueryInList(string fieldName, params string[] values) : this(fieldName, (IEnumerable<string>) values) {}

        public string Query {
            get { return q; }
        }
    }
}