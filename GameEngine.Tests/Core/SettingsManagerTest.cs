using GameEngine.Core;
using GameEngine.GameObjects.ServiceObjects;
using GameEngine.Interfaces.DataAccess;
using GameEngine.Interfaces.Factories;
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
        private Mock<ISettingsFactory> _settingsFactoryMock;
        private Mock<Settings> _settingsMock;

        private Settings _settings;

        private readonly string _currentSettingsKey = "CurrentSettingsKey";

        private SettingsManager _settingsManager;

        [TestInitialize]
        public void TestInitialize()
        {
            _settingProviderMock = new Mock<ISettingsProvider>();
            _dataStorageMock = new Mock<IDataStorage>();
            _settingsFactoryMock = new Mock<ISettingsFactory>();
            _settingsMock = new Mock<Settings>();

            _settings = new Settings();

            _settingsManager =
                new SettingsManager(_settingProviderMock.Object, _dataStorageMock.Object, _settingsFactoryMock.Object);
        }

        [TestMethod]
        public void GetSettings_StorageReturnValue_SettingsReturned()
        {
            //arrange
            _dataStorageMock.Setup(s => s.GetValue<Settings>(_currentSettingsKey)).Returns(_settings);

            //action
            var resultSettings = _settingsManager.GetSettings();

            //assert
            Assert.AreEqual(_settings.AntialiasingLevel, resultSettings.AntialiasingLevel);
        }

        [TestMethod]
        public void GetSettings_StorageReturnNullAndProviderReturnValue_SettingsReturned()
        {
            //arrange
            _dataStorageMock.Setup(s => s.GetValue<Settings>(_currentSettingsKey)).Returns<Settings>(null);
            _settingProviderMock.Setup(s => s.Get()).Returns(_settings);

            //action
            var resultSettings = _settingsManager.GetSettings();

            //assert
            Assert.AreEqual(_settings.AntialiasingLevel, resultSettings.AntialiasingLevel);
        }

        [TestMethod]
        public void GetSettings_StorageReturnNull_SetValueInvoked()
        {
            //arrange
            _dataStorageMock.Setup(s => s.GetValue<Settings>(_currentSettingsKey)).Returns<Settings>(null);

            //action
            var resultSettings = _settingsManager.GetSettings();

            //assert
            _dataStorageMock.Verify(s => s.SetValue(_currentSettingsKey, It.IsAny<Settings>()), Times.Once());
        }

        [TestMethod]
        public void GetSettings_StorageAndProviderReturnNullAndFactoryReturnValue_SettingsReturned()
        {
            //arrange
            _dataStorageMock.Setup(s => s.GetValue<Settings>(_currentSettingsKey)).Returns<Settings>(null);
            _settingProviderMock.Setup(s => s.Get()).Returns<Settings>(null);
            _settingsFactoryMock.Setup(s => s.CreateDefault()).Returns(_settings);

            //action
            var resultSettings = _settingsManager.GetSettings();

            //assert
            Assert.AreEqual(_settings.AntialiasingLevel, resultSettings.AntialiasingLevel);
        }

        [TestMethod]
        public void GetSettings_StorageAndProviderReturnNull_SaveInvoked()
        {
            //arrange
            _dataStorageMock.Setup(s => s.GetValue<Settings>(_currentSettingsKey)).Returns<Settings>(null);
            _settingProviderMock.Setup(s => s.Get()).Returns<Settings>(null);

            //action
            var resultSettings = _settingsManager.GetSettings();

            //assert
            _settingProviderMock.Verify(s => s.Save(It.IsAny<Settings>()), Times.Once());
        }
    }
}
