using GameEngine.GameObjects.ServiceObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces.Core
{
    public interface ISettingsManager
    {
        Settings GetSettings();
        Settings SaveSettings(Settings settingsForSave);
    }
}
