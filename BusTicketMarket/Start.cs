using Core;
using Interfaces;
using Models;

namespace ClientApplication
{
    /**
     * Основной класс клиентского приложения.
     */
    internal class Start : EnterData
    {
        // Связь с основной логикой осуществляется через интерфейс ICustomer.
        private ICustomer customer;
        private int ticketRouteNumber;
        private DateTime ticketDate;

        /**
         * Метод запуска меню входа и регистрации
         */
        public void RunLoginRegisterMenu()
        {
            bool run = true;
            while (run)
            {
                printMessageLine("Application for buying bus tickets");
                printMessageLine("This is a test version. The data base is not available in full mode.");
                printMessageLine("To login\t\t\tenter 1\nTo register\t\t\tenter 2\nTo exit\t\t\t\tenter 0");
                Console.WriteLine("Enter your choice > ");
                int choice = 0;
                try
                {
                    choice = InputInt(0, 2);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                Console.WriteLine("=====================================================================================");
                run = RunLoginRegisterMenuChoiceLogic(choice);
            }
        }

        /// <summary>
        /// Логика ветвления запуска программы
        /// </summary>
        /// <param name="choice"></param>
        /// <returns></returns>
        private bool RunLoginRegisterMenuChoiceLogic(int choice)
        {
            switch (choice)
            {
                case 1:
                    login();
                    if (customer.GetUser() == null)
                    {
                        break;
                    }
                    else
                    {
                        runBuyingMenu();
                        break;
                    }
                case 2:
                    register();
                    if (customer == null)
                    {
                        break;
                    }
                    else
                    {
                        runBuyingMenu();
                        break;
                    }
                default:
                    return false;
            }
            return true;
        }

        /**
         * Меню входа зарегестрированного пользователя
         */
        private void login()
        {
            printMessageLine("This is a test version. The data base is not available in full mode.");
            printMessageLine("Login");
            Console.WriteLine("User name: ");
            string userName = InputString();
            Console.WriteLine("Password: ");
            int passwordHash = InputString().GetHashCode();
            Console.WriteLine("=====================================================================================");
            Console.Write("Enter the system... ");
            customer = new Customer();
            try
            {
                customer.SetUser(Authentication.AuthenticationRequest(customer.GetUserProvider(), userName, passwordHash));
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=====================================================================================");
                return;
            }
            printMessageLine("OK");
        }

        /**
         * Меню регистрации нового пользователя
         */
        private void register()
        {
            printMessageLine("This is a test version. The data base is not available in full mode.");
            printMessageLine("Register");
            Console.Write("Enter user name: ");
            string userName = InputString();
            Console.Write("Enter password: ");
            int passwordHash = InputString().GetHashCode();
            Console.Write("Repeat password: ");
            int passwordHash2 = InputString().GetHashCode();
            if (passwordHash != passwordHash2)
            {
                Console.WriteLine("=====================================================================================");
                printMessageLine("Passwords do not match. Exit register.");
                return;
            }
            Console.Write("Enter card number: ");
            long cardNumber = InputLong(1L, 9999_9999_9999_9999L);
            Console.WriteLine("=====================================================================================");
            Console.Write("Register the system... ");
            customer = new Customer();
            int id;
            try
            {
                id = customer.GetUserProvider().CreateClient(userName, passwordHash, cardNumber);
                customer.SetUser(Authentication.AuthenticationRequest(customer.GetUserProvider(), userName, passwordHash));
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL");
                Console.WriteLine(ex.Message);
                Console.WriteLine("=====================================================================================");
                return;
            }
            printMessageLine("OK. user " + customer.GetUser().UserName + " with ID " + id + "added to base.");
        }

        /**
         * Меню покупки билетов
         */
        private void runBuyingMenu()
        {
            bool run = true;
            while (run)
            {
                printMessageLine("Application for buying bus tickets. | User " + customer.GetUser().UserName + " |");
                printMessageLine("To select route number and print all tickets\tenter 1\n" +
                        "To logout\t\t\t\t\tenter 0");
                Console.Write("Enter your choice > ");
                int choice = 0;
                try
                {
                    choice = InputInt(0, 1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("==============================================================================" +
                            "=======");
                    printMessageLine(ex.Message);
                    continue;
                }
                Console.WriteLine("=====================================================================================");
                run = runBuyingMenuChoiceLogic(choice);
            }
        }

        /**
         * Логика ветвления меню покупки билетов
         *
         * @param choice
         * @return
         */
        private bool runBuyingMenuChoiceLogic(int choice)
        {
            switch (choice)
            {
                case 1:
                    ticketRouteNumber = runSelectRouteMenu();
                    if (ticketRouteNumber > 0)
                    {
                        ticketDate = runSelectDate();
                        if (ticketDate != null)
                        {
                            try
                            {
                                customer.SetSelectedTickets(customer.SearchTicket(ticketDate, ticketRouteNumber));
                            }
                            catch (Exception ex)
                            {
                                printMessageLine(ex.Message);
                                return true;
                            }
                            printAllTickets(customer.GetSelectedTickets());
                            buyTicketMenu();
                            return true;
                            //return;
                        }
                        return true;
                    }
                    return true;
                default:
                    return false;
            }
        }

        /**
         * Метод ввода номера маршрута
         *
         * @return номер маршрута
         */
        private int runSelectRouteMenu()
        {
            printMessageLine("Input route number and date. | User " + customer.GetUser().UserName + " |");
            Console.Write("Route number > ");
            //Здесь ограничиваем число маршрутов. У нас всего 2 маршрута.
            int numRoute;
            try
            {
                numRoute = InputInt(1, 2);
            }
            catch (Exception ex)
            {
                printMessageLine(ex.Message);
                return -1;
            }
            Console.WriteLine("=====================================================================================");
            return numRoute;
        }

        /**
         * Метод ввода даты поездки
         *
         * @return дата поездки
         */
        private DateTime runSelectDate()
        {
            Console.Write("Date (format: YYYY-MM-DD) > ");
            //Здесь ограничиваем число маршрутов. У на всего 2 маршрута.
            DateTime date;
            try
            {
                date = InputDate();
            }
            catch (Exception ex)
            {
                printMessageLine(ex.Message);
                return default;
            }
            Console.WriteLine("=====================================================================================");
            return date;
        }

        /**
         * Метод вывода в консоль списка билетов
         *
         * @param ticks список билетов
         */
        private void printAllTickets(List<Ticket> ticks)
        {
            foreach (var t in ticks)
            {
                Console.WriteLine(t.ToString());
            }
            Console.WriteLine("=====================================================================================");
        }

        /**
         * Метод покупки билета
         */
        private void buyTicketMenu()
        {
            printMessageLine("Confirm to buy. | User " + customer.GetUser().UserName + " |");
            Console.Write("To buy a ticket for bus route " + ticketRouteNumber + " on the " + ticketDate + " enter" +
                    " \"Yes\" > ");
            String answer = InputString();
            Console.WriteLine("=====================================================================================");
            buyTicketMenuConfirmLogic(answer);
        }

        /**
         * Логика ветвления меню подтверждения покупки
         *
         * @param answer
         */
        private void buyTicketMenuConfirmLogic(string answer)
        {
            if (answer.ToLower().Equals("YES".ToLower()))
            {
                foreach (var t in customer.GetSelectedTickets())
                {
                    if (t.Date.Equals(ticketDate) && t.RouteNumber == ticketRouteNumber && t.GetValid())
                    {
                        bool flag = false;
                        try
                        {
                            flag = customer.BuyTicket(t);
                        }
                        catch (Exception ex)
                        {
                            printMessageLine(ex.Message);
                            return;
                        }
                        if (flag)
                        {
                            printMessageLine(t.ToPrint());
                            return;
                        }
                    }
                }
            }
            else Console.WriteLine("User has not confirmed the purchase");
        }

        /**
         * Метод вывода в консоль элемента сообщения
         *
         * @param message
         */
        private void printMessageLine(String message)
        {
            Console.WriteLine(message);
            Console.WriteLine("=====================================================================================");
        }
    }
}
