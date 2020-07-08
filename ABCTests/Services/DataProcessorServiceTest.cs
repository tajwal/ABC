using ABC.Broker;
using ABC.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Tynamix.ObjectFiller;
using Xunit;


namespace ABCTest
{
    public class DataProcessorServiceTests
    {
        [Fact]
        public void StorageBrokerTest()
        {
            //given

            var storageBrokerMock = new Mock<IStorageBroker>();
            var returnedDataFiller = new Filler<string>();
            List<string> retunedData = returnedDataFiller.Create(10).ToList();

            storageBrokerMock.Setup(broker => broker.GetAllData())
                .Returns(retunedData);

            List<string> ExpectedResult = 
                retunedData.Select(item => item.ToUpper()).ToList();
            //when
            var dataProcessorService = new DataProcessorServices(storageBrokerMock.Object);

          List<string> actualResult=  dataProcessorService.ProcessData();

            //Then

            storageBrokerMock.Verify(broker => 
                  broker.GetAllData(), Times.Once
                ,"Storage Broker Should be called at least once for data processing");


           
            actualResult.Should()
                        .BeEquivalentTo(ExpectedResult,
                        because:"Return List should be both Upper Case");
        }

       
    }
}
