using GameEngine.Core;
using GameEngine.GameObjects.ServiceObjects;
using GameEngine.Interfaces.DataAccess;
using GameEngine.Interfaces.Storages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GameEngine.Tests.Core
{
    [TestClass]
    public class SettingsManagerTest
    {
        [TestMethod]
        public void GetSettings_StorageAndProviderReturn_SettingsReturned()
        {
            var settings = new Settings();

            var settingsProvider = Mock.Of<ISettingsProvider>(s => s.Get() == settings);
            var storage = Mock.Of<IDataStorage>(d => d.GetValue<Settings>("CurrentSettingsKey") == settings);

            var settingsManager = new SettingsManager(settingsProvider, storage);

            var result = settingsManager.GetSettings();

            Assert.AreEqual(settings, result);
            Assert.IsNotNull(result);
        }
    }
}
