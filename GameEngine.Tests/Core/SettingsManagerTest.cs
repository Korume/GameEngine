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
        private Mock<ISettingsProvider> _settingProviderMock;
        private Mock<IDataStorage> _dataStorageMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _settingProviderMock = new Mock<ISettingsProvider>();
            _dataStorageMock = new Mock<IDataStorage>();
        }

        [TestMethod]
        public void GetSettings_StorageReturnNull_SettingsReturned()
        {
            var settings = new Settings();

            var currentSettingsKey = "CurrentSettingsKey";
            _dataStorageMock.Setup(s => s.GetValue<Settings>(currentSettingsKey)).Returns<Settings>(null);
            _settingProviderMock.Setup(s => s.Get()).Returns(settings);

            var settingsManager = new SettingsManager(_settingProviderMock.Object, _dataStorageMock.Object);

            var result = settingsManager.GetSettings();

            Assert.AreEqual(settings.AntialiasingLevel, result.AntialiasingLevel);
        }
    }
}
