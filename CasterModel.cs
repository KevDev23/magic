using System;
using System.Collections.Generic;
using System.Text;

namespace magic
{
    class CasterModel
    {
    /// <summary>
    /// Character level, for display purposes and determining maxHP
    /// </summary>
        public int level { get; set; }
        /// <summary>
        /// The amount of magic points a character currently has
        /// </summary>
        public int mp { get; set; } 
        /// <summary>
        /// The magic point maximum determined by level
        /// </summary>
        public int maxMP { get; set; }
        /// <summary>
        /// The maximum mp a character can have determined by level
        /// </summary>
        public string characterName  { get; set; }
    }
}
