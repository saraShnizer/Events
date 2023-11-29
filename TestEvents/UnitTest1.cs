
using events;
using events.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestEvents
{
    public class UnitTest1
    {
        private readonly EventsController _eventsController;
        public UnitTest1()
        {
            var context = new FakeDataContext();
            _eventsController = new EventsController(context);
        }
        [Fact]
        public void Get_ReturnOk()
        {
            var result = _eventsController.Get();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_ReturnNotFound()
        {
            int id = 3;

            var result = _eventsController.Get(id);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}