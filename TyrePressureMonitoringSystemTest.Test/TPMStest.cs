using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TyrePressureMonitoringSystem;
using System.Reflection;

namespace TyrePressureMonitoringSystemTest.Test
{
    public class TPMStest
    {

        
        Type sensorType = typeof(Sensor);
        Type alarmType = typeof(Alarm);


        [Test]
        public void PressureLowerThanTheLowestPressureLimitShouldTriggerTheAlarm()
        {
            //Arrange

            var valueLowerThanLowestLimit = 15;
            Mock<ISensor> mockedSensor = new Mock<ISensor>();
            mockedSensor.Setup(p => p.PopNextPressurePsiValue()).Returns(valueLowerThanLowestLimit);

            Alarm instance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic| BindingFlags.SetField);
            MethodInfo check = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            sensor.SetValue(instance, mockedSensor.Object);

            //Assert
            Assert.AreEqual(instance.AlarmOn, false);

            check.Invoke(instance, null);

            Assert.AreEqual(instance.AlarmOn, true);
        }

        [Test]
        public void ValidLowerValueShouldNotTriggerAlarm()
        {

            Mock<ISensor> mockedSensor = new Mock<ISensor>();
            mockedSensor.Setup(p => p.PopNextPressurePsiValue()).Returns(17);

            var instance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo check = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);
            sensor.SetValue(instance, 17);

            //Assert
            Assert.AreEqual(instance.AlarmOn, false);
            check.Invoke(alarmType, null);
            Assert.AreEqual(instance.AlarmOn, false);

        }

        [Test]
       
        public void ValidValueDoesNotTriggerAlarm()
        {
            Mock<ISensor> mockedSensor = new Mock<ISensor>();
            mockedSensor.Setup(p => p.PopNextPressurePsiValue()).Returns(19);
            var instance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo check = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            sensor.SetValue(instance, 19);

            //Assert
            Assert.AreEqual(instance.AlarmOn, false);
            check.Invoke(alarmType, null);
            Assert.AreEqual(instance.AlarmOn, false);
        }
        [Test]
        public void TopBorderPressureShouldNotActivateAlarm()
        {
            Mock<ISensor> mockedSensor = new Mock<ISensor>();

            mockedSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(21);

            Type alarmType = typeof(Alarm);

            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            sensor.SetValue(classInstance, mockedSensor.Object);

            Assert.That(classInstance.AlarmOn, Is.EqualTo(false));

            checkMethod.Invoke(classInstance, null);

            Assert.That(classInstance.AlarmOn, Is.EqualTo(false));
        }

        [Test]
        public void PressureHigherThanTheHighestLimitShouldActivateAlarm()
        {
            Mock<ISensor> mockedSensor = new Mock<ISensor>();

            mockedSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(24);

            Type alarmType = typeof(Alarm);

            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            sensor.SetValue(classInstance, mockedSensor.Object);

            Assert.That(classInstance.AlarmOn, Is.EqualTo(false));

            checkMethod.Invoke(classInstance, null);

            Assert.That(classInstance.AlarmOn, Is.EqualTo(true));
        }
    }
}
