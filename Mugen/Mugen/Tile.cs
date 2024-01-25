using System;
using System.Windows.Controls;

namespace Mugen
{
    public class Tile 
    {
        public DateTime DateCreation;
        public bool isUsed;
        public Grid tile;
        public TextBlock TaskText;
        public TextBlock DescriptionText;
        public Tile(Grid _tile, TextBlock _TaskText, TextBlock _DescriptionText, bool _isUsed, DateTime _dateCreation)
        {
            this.DescriptionText = _DescriptionText;
            this.TaskText = _TaskText;
            this.tile = _tile;
            this.isUsed = _isUsed;
            this.DateCreation = _dateCreation;
        }
    }
}
