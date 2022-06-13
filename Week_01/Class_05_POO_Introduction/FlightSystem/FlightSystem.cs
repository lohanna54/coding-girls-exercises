using System;
using System.Linq;

namespace Class_05_POOIntroduction.FlightSystem
{
    public static class FlightSystem
    {
        public static void Start()
        {
            var dateTimeNow = DateTime.Now;
            dateTimeNow = dateTimeNow.AddDays(7);
            DateTime scheduledDate = dateTimeNow.AddHours(12);

            var flight = new FlightData(scheduledDate, 100);

            var shouldExecute = true;

            do
            {
                Console.WriteLine("O que deseja fazer?" +
                    "\n1. Ocupar vaga" +
                    "\n2. Vagas livres" +
                    "\n3. Cadeira livre" +
                    "\n4. Ocupa" +
                    "\n5. Ver horário");

                if (int.TryParse(Console.ReadLine(), out int selectedOption) && selectedOption is >= 1 and <= 9)
                {
                    switch (selectedOption)
                    {
                        case 1:
                            VacancyReservation(flight, false);
                            break;
                        case 2:
                            ShowAvailableVacancies(flight);
                            break;
                        case 3:
                            ShowNextAvailableVacancy(flight);
                            break;
                        case 4:
                            VacancyReservation(flight, true);
                            break;
                        case 5:
                            ShowFlightScheduledDate(flight);
                            break;
                    }

                    Console.WriteLine("Deseja realizar outra operação? S/N");
                    var chosenOption = char.ToUpper(Console.ReadLine()[0]);

                    shouldExecute = chosenOption is 'S';
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }

            } while (shouldExecute);
        }

        private static void VacancyReservation(FlightData flight, bool showMessage)
        {
            Console.WriteLine("Número da vaga:");

            if (int.TryParse(Console.ReadLine(), out int vacancyNumber) && vacancyNumber is >= 1 and <= 100)
            {
                vacancyNumber--;

                if (!showMessage)
                {
                    Console.WriteLine(SuccessInFillVacancy(flight, vacancyNumber));
                }
                else
                {
                    if (SuccessInFillVacancy(flight, vacancyNumber))
                    {
                        Console.WriteLine($"Sucesso. A vaga n° {vacancyNumber + 1} foi reservada");
                    }
                    else
                    {
                        Console.WriteLine($"Falha. A vaga n° {vacancyNumber + 1} já foi preenchida.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Vaga inválida");
            }
        }

        private static bool SuccessInFillVacancy(FlightData flight, int vacancyNumber)
        {
            if (flight.FilledVacancies[vacancyNumber])
            {
                return false;
            }

            flight.FilledVacancies[vacancyNumber] = true;
            return true;
        }

        private static void ShowAvailableVacancies(FlightData flight)
        {
            var vacanciesCount = flight.FilledVacancies.Count(f => !f);
            Console.WriteLine($"Vagas disponíveis: {vacanciesCount}");
        }

        private static void ShowNextAvailableVacancy(FlightData flight)
        {
            var availableVacancy = Array.FindIndex(flight.FilledVacancies, f => !f);
            Console.WriteLine($"Próxima cadeira livre: {availableVacancy + 1}");
        }

        private static void ShowFlightScheduledDate(FlightData flight)
        {
            Console.WriteLine($"Data e hora do vôo: {flight.ScheduledDate}");
        }
    }
}
