Practice 10 1.1;

namespace HotelFacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var hotelFacade = new HotelFacade();
            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(3);

            // Вызов фасада для бронирования номера с необходимыми услугами
            hotelFacade.BookRoom(startDate, endDate, 3);

            // Организация мероприятия с бронированием помещений и заказом оборудования
            hotelFacade.OrganizeEvent("Конференция", 100);
        }
    }

    public class HotelFacade
    {
        private RoomBookingSystem _roomBookingSystem;
        private CleaningService _cleaningService;
        private RestaurantService _restaurantService;
        private EventManagementSystem _eventManagementSystem;

        public HotelFacade()
        {
            _roomBookingSystem = new RoomBookingSystem();
            _cleaningService = new CleaningService();
            _restaurantService = new RestaurantService();
            _eventManagementSystem = new EventManagementSystem();
        }

        // Фасадный метод для бронирования номера и организации дополнительных услуг
        public void BookRoom(DateTime startDate, DateTime endDate, int peopleAmount)
        {
            _roomBookingSystem.MakeReservation(startDate, endDate, peopleAmount);
            _roomBookingSystem.Payment(500); // Примерная сумма оплаты

            _cleaningService.Notify(startDate, endDate, peopleAmount);
            _restaurantService.Notify(peopleAmount); // Сервировка столов для гостей
        }

        // Фасад для организации корпоративного мероприятия
        public void OrganizeEvent(string eventName, int participants)
        {
            _eventManagementSystem.OrganizeEvent(eventName, participants);
            _eventManagementSystem.OrderEquipment("Проектор");
            _roomBookingSystem.MakeReservation(DateTime.Now, DateTime.Now.AddDays(1), participants);
        }
    }

    public class RoomBookingSystem
    {
        // Метод для бронирования номера на заданные даты
        public void MakeReservation(DateTime startTime, DateTime endTime, int peopleAmount)
        {
            Console.WriteLine($"Забронирован номер с {startTime} по {endTime} для {peopleAmount} человек.");
        }

        // Метод для выполнения оплаты за услуги
        public void Payment(double pay)
        {
            Console.WriteLine($"Осуществлена оплата на сумму: {pay} рублей.");
        }
    }

    public class RestaurantService
    {
        // Уведомление ресторана о заказе стола и количестве гостей
        public void Notify(int peopleAmount)
        {
            Console.WriteLine($"Резервирование стола для {peopleAmount} человек в ресторане.");
        }
    }

    public class EventManagementSystem
    {
        // Организация мероприятия и расчет количества участников
        public void OrganizeEvent(string eventName, int participants)
        {
            Console.WriteLine($"Организация события: {eventName} для {participants} человек.");
        }

        // Заказ необходимого оборудования для мероприятия
        public void OrderEquipment(string equipment)
        {
            Console.WriteLine($"Заказ оборудования: {equipment}");
        }
    }

    public class CleaningService
    {
        // Оповещение службы уборки о необходимости уборки номеров
        public void Notify(DateTime startDate, DateTime endDate, int roomNum)
        {
            Console.WriteLine($"Запланирована уборка номера с {startDate} по {endDate} для номера: {roomNum}");
        }
    }
}
