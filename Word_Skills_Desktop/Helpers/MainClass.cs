using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Word_Skills_Desktop.Models;

namespace Word_Skills_Desktop.Helpers
{
    public static class MainClass
    {
        public static Frame FrameMainStruct { get; set; }
        public static WorldSkillsEntities Context {  get; set; }
        public static Doctors Doctor { get; set; }
    }
}
