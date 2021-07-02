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
        
        /// <summary>
        /// sets the maxMP based on level.
        /// </summary>
        public void determineMaxMP()
        {
            switch(level)
            {
                case 1:
                    maxMP = 4;
                    break;

                case 2:
                    maxMP = 6;
                    break;

                case 3:
                    maxMP = 14;
                    break;

                case 4:
                    maxMP = 17;
                    break;

                case 5:
                    maxMP = 27;
                    break;

                case 6:
                    maxMP = 32;
                    break;

                case 7:
                    maxMP = 38;
                    break;

                case 8:
                    maxMP = 44;
                    break;

                case 9:
                    maxMP = 57;
                    break;

                case 10:
                    maxMP = 64;
                    break;

                case 11:
                    maxMP = 73;
                    break;

                case 12:
                    maxMP = 73;
                    break;

                case 13:
                    maxMP = 83;
                    break;

                case 14:
                    maxMP = 83;
                    break;

                case 15:
                    maxMP = 94;
                    break;

                case 16:
                    maxMP = 94;
                    break;

                case 17:
                    maxMP = 107;
                    break;

                case 18:
                    maxMP = 114;
                    break;

                case 19:
                    maxMP = 123;
                    break;

                case 20:
                    maxMP = 133;
                    break;

                default:
                    Console.WriteLine("Error: In determineMaxMP, level is: ", level);
                    break;


            }
            
        }
    }
}
