using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneWarsStory.Core.Models
{
    /// <summary>
    /// Prochain de pas de déplacement
    /// </summary>
    public interface IProchainPas
    {
        /// <summary>
        /// Prochaine position
        /// </summary>
        /// <returns></returns>
        Position GetNext();

        bool IsValidPosition(Position position);
    }
}
