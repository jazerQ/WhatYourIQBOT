using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace tgBotBrainzIQ
{
    internal class Program
    {
        static int count_true = 0;
        private static ITelegramBotClient _botClient;
        private static ReceiverOptions _receiverOptions;
        static async Task Main(string[] args)
        {
            _botClient = new TelegramBotClient("7209638331:AAG7nRqm_HIH7Zr7IfbdFM-r8mlbxNYzK4c");
            _receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new[]
                {
                    UpdateType.Message,
                },
                ThrowPendingUpdates = true,
            };
            var cts = new CancellationTokenSource();
            _botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts.Token);
            var me = await _botClient.GetMeAsync();
            await Task.Delay(-1);
        }
        private static Task ErrorHandler(ITelegramBotClient client, Exception exception, CancellationToken token)

        {

            throw new NotImplementedException();

        }
        private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            //блок try-catch, чтобы наш бот не "падал" в случае каких-либо ошибок
            try
            {
                switch (update.Type)
                {
                    case UpdateType.Message:
                        {
                            var message = update.Message;
                            List<string> answer = new List<string>();
                            for(int i = 0; i < 10; i++)
                            {
                                answer.Add(message.Text);
                            }
                            List<T> removeDuplicates<T>(List<T> list)
                            {
                                return new HashSet<T>(list).ToList();
                            }
                            List<string> answer_itog = removeDuplicates(answer);
                            var chat = message.Chat;
                            switch (message.Type)
                            {
                                case MessageType.Text:
                                    {
                                        if(message.Text == "/start")
                                        {
                                            count_true = 0;
                                            await botClient.SendTextMessageAsync(
                                                chat.Id,
                                                $"Приветствую тебя, {chat.Username}. Данный бот может узнать твой IQ");
                                            var start_btn = new ReplyKeyboardMarkup(
                                                new List<KeyboardButton[]>()
                                                {
                                                    new KeyboardButton[]
                                                    {
                                                        new KeyboardButton("Пройти тест на IQ"),
                                                    }
                                                }
                                                );
                                            await botClient.SendTextMessageAsync(chat.Id, "Начнем!", replyMarkup: start_btn);
                                            return;
                                        }
                                        else if(message.Text == "Пройти тест на IQ")
                                        {
                                            await botClient.SendTextMessageAsync(
                                                    chat.Id, "Отвечайте на вопросы, выбирая ответы с помощью кнопок"
                                                );
                                            var question_1 = new ReplyKeyboardMarkup(
                                                    new List<KeyboardButton[]>()
                                                    {
                                                        new KeyboardButton[]
                                                        {
                                                            new KeyboardButton("15"),
                                                            new KeyboardButton("14"),
                                                            new KeyboardButton("22"),
                                                            new KeyboardButton("17"),
                                                        },
                                                    }
                                                )
                                            {
                                                ResizeKeyboard = true,
                                            };
                                            await botClient.SendTextMessageAsync(chat.Id, "Вставьте пропущенную цифру. \r\n2 5 8 11 _", replyMarkup: question_1);
                                            return;
                                        }
                                        else if(message.Text == "14" | message.Text == "15" | message.Text == "22" | message.Text == "17")
                                        {
                                            if(message.Text == "14")
                                            {
                                                count_true++;
                                                Console.WriteLine(count_true);
                                            }
                                            var question_2 = new ReplyKeyboardMarkup(
                                                    new List<KeyboardButton[]>()
                                                    {
                                                        new KeyboardButton[]
                                                        {
                                                            new KeyboardButton("дом"),
                                                            new KeyboardButton("иглу"),
                                                            new KeyboardButton("бунгало"),
                                                            new KeyboardButton("офис"),
                                                            new KeyboardButton("хижина"),
                                                        },
                                                    }
                                                ); ;
                                            await botClient.SendTextMessageAsync(chat.Id, "Выберите лишнее слово. \r\n дом иглу бунгало офис хижина", replyMarkup: question_2);
                                            return;
                                        }
                                        else if(message.Text == "дом" | message.Text == "иглу" | message.Text == "бунгало" | message.Text == "офис" | message.Text == "хижина")
                                        {
                                            if(message.Text == "офис")
                                            {
                                                count_true++;
                                                Console.WriteLine(count_true);
                                            }
                                            var question_3 = new ReplyKeyboardMarkup(
                                                new List<KeyboardButton[]>()
                                                {
                                                    new KeyboardButton[]
                                                    {
                                                        new KeyboardButton("селедка"),
                                                        new KeyboardButton("кит"),
                                                        new KeyboardButton("акула"),
                                                        new KeyboardButton("барракуда"),
                                                        new KeyboardButton("треска"),
                                                    },
                                                }
                                                ); ;
                                            await botClient.SendTextMessageAsync(chat.Id, "Выберите лишнее слово. \r\nселедка кит акула барракуда треска", replyMarkup: question_3);
                                            return;
                                        }
                                        else if(message.Text == "селедка" | message.Text == "кит" | message.Text == "акула" | message.Text == "барракуда" | message.Text == "треска")
                                        {
                                            if(message.Text == "кит")
                                            {
                                                count_true++;
                                                Console.WriteLine(count_true);
                                            }
                                            var question_4 = new ReplyKeyboardMarkup(
                                                new List<KeyboardButton[]>()
                                                {
                                                    new KeyboardButton[]
                                                    {
                                                        new KeyboardButton("РОФД"),
                                                        new KeyboardButton("ТБНЕИЛ"),
                                                        new KeyboardButton("ТАИФ"),
                                                        new KeyboardButton("ОЖЕП"),
                                                        new KeyboardButton("ГБИОН"),
                                                    },
                                                }
                                                ); ;
                                            await botClient.SendTextMessageAsync(chat.Id, "Выберите сочетание, не образующее марку автомобиля. \r\nРОФД  ТБНЕИЛ  ТАИФ  ОЖЕП  ГБИОН", replyMarkup: question_4);
                                            return;

                                        }
                                        else if (message.Text == "РОФД" | message.Text == "ТБНЕИЛ" | message.Text == "ТАИФ" | message.Text == "ОЖЕП" | message.Text == "ГБИОН")
                                        {
                                            if (message.Text == "ГБИОН")
                                            {
                                                count_true++;
                                                Console.WriteLine(count_true);
                                            }
                                            var question_5 = new ReplyKeyboardMarkup(
                                                new List<KeyboardButton[]>()
                                                {
                                                    new KeyboardButton[]
                                                    {
                                                        new KeyboardButton("14 13"),
                                                        new KeyboardButton("14 18"),
                                                        new KeyboardButton("14 14"),
                                                        new KeyboardButton("15 10"),
                                                        new KeyboardButton("9 10"),
                                                    },
                                                }
                                                ); ;
                                            await botClient.SendTextMessageAsync(chat.Id, "Найдите недостающие числа. \r\n7 10 9 12 11 _ _", replyMarkup: question_5);
                                            return;

                                        }
                                        else if (message.Text == "14 13" | message.Text == "14 18" | message.Text == "14 14" | message.Text == "15 10" | message.Text == "9 10"){

                                            if (message.Text == "14 13")
                                            {
                                                count_true++;
                                                Console.WriteLine(count_true);
                                            }
                                            var question_6 = new ReplyKeyboardMarkup(
                                                new List<KeyboardButton[]>()
                                                {
                                                    new KeyboardButton[]
                                                    {
                                                        new KeyboardButton("червь"),
                                                        new KeyboardButton("радуга"),
                                                        new KeyboardButton("лужи"),
                                                        new KeyboardButton("грибной"),
                                                        new KeyboardButton("мокрый"),
                                                    },
                                                }
                                                ); ;
                                            await botClient.SendTextMessageAsync(chat.Id, "Вставьте в скобки недостающее слово. \r\nлуг (зеленый) юнец \nлес (.......) дождь", replyMarkup: question_6);
                                            return;

                                        }
                                        else if (message.Text == "червь" | message.Text == "радуга" | message.Text == "лужи" | message.Text == "грибной" | message.Text == "мокрый")
                                        {

                                            if (message.Text == "грибной")
                                            {
                                                count_true++;
                                                Console.WriteLine(count_true);
                                            }
                                            var question_7 = new ReplyKeyboardMarkup(
                                                new List<KeyboardButton[]>()
                                                {
                                                    new KeyboardButton[]
                                                    {
                                                        new KeyboardButton("ЙОРБАН"),
                                                        new KeyboardButton("ШПУИНК"),
                                                        new KeyboardButton("СТИК"),
                                                        new KeyboardButton("ЛОТАНП"),
                                                        new KeyboardButton("МОРЛЕНВОТ"),
                                                    },
                                                }
                                                ); ;
                                            await botClient.SendTextMessageAsync(chat.Id, "Выберите сочетание, не образующее фамилию знаменитого поэта. \r\nЙОРБАН  ШПУИНК  СТИК  ЛОТАНП  МОРЛЕНВОТ", replyMarkup: question_7);
                                            return;

                                        }
                                        else if (message.Text == "ЙОРБАН" | message.Text == "ШПУИНК" | message.Text == "СТИК" | message.Text == "ЛОТАНП" | message.Text == "МОРЛЕНВОТ")
                                        {

                                            if (message.Text == "ЛОТАНП")
                                            {
                                                count_true++;
                                                Console.WriteLine(count_true);
                                            }
                                            var question_8 = new ReplyKeyboardMarkup(
                                                new List<KeyboardButton[]>()
                                                {
                                                    new KeyboardButton[]
                                                    {
                                                        new KeyboardButton("ПОНЕШ"),
                                                        new KeyboardButton("ОЛЕСАЯМ"),
                                                        new KeyboardButton("ОТЦАМР"),
                                                        new KeyboardButton("БУРШЕТ"),
                                                        new KeyboardButton("УСТРАШ"),
                                                    },
                                                }
                                                ); ;
                                            await botClient.SendTextMessageAsync(chat.Id, "Выберите сочетание, не образующее фамилию знаменитого Композитора. \r\nПОНЕШ  ОЛЕСАЯМ  ОТЦАМР  БУРШЕТ  УСТРАШ", replyMarkup: question_8);
                                            return;

                                        }
                                        else if (message.Text == "ПОНЕШ" | message.Text == "ОЛЕСАЯМ" | message.Text == "ОТЦАМР" | message.Text == "БУРШЕТ" | message.Text == "УСТРАШ")
                                        {

                                            if (message.Text == "ОЛЕСАЯМ")
                                            {
                                                count_true++;
                                                Console.WriteLine(count_true);
                                            }
                                            var question_9 = new ReplyKeyboardMarkup(
                                                new List<KeyboardButton[]>()
                                                {
                                                    new KeyboardButton[]
                                                    {
                                                        new KeyboardButton("Р"),
                                                        new KeyboardButton("М"),
                                                        new KeyboardButton("А"),
                                                        new KeyboardButton("Ш"),
                                                        new KeyboardButton("Б"),
                                                    },
                                                }
                                                ); ;
                                            await botClient.SendTextMessageAsync(chat.Id, "Вставьте недостающую букву. \r\nМ П И\nР У Н\nД Ж _", replyMarkup: question_9);
                                            return;

                                        }
                                        else if (message.Text == "Р" | message.Text == "М" | message.Text == "А" | message.Text == "Ш" | message.Text == "Б")
                                        {

                                            if (message.Text == "Б")
                                            {
                                                count_true++;
                                                Console.WriteLine(count_true);
                                            }
                                            var question_10 = new ReplyKeyboardMarkup(
                                                new List<KeyboardButton[]>()
                                                {
                                                    new KeyboardButton[]
                                                    {
                                                        new KeyboardButton("Канберра"),
                                                        new KeyboardButton("Вашингтон"),
                                                        new KeyboardButton("Лондон"),
                                                        new KeyboardButton("Париж"),
                                                        new KeyboardButton("Нью-Йорк"),
                                                        new KeyboardButton("Берлин"),
                                                        new KeyboardButton("Оттава"),
                                                    },
                                                }
                                                ); ;
                                            await botClient.SendTextMessageAsync(chat.Id, "Выберите лишние названия городов. \r\nКанберра  Вашингтон  Лондон  Париж  Нью-Йорк  Берлин  Оттава", replyMarkup: question_10);
                                            return;

                                        }
                                        else if (message.Text == "Канберра" | message.Text == "Вашингтон" | message.Text == "Лондон" | message.Text == "Париж" | message.Text == "Нью-Йорк" | message.Text == "Берлин" | message.Text == "Оттава")
                                        {
                                            if (message.Text == "Нью-Йорк") count_true += 1; Console.WriteLine(count_true); ;
                                            var question_11 = new ReplyKeyboardMarkup(
                                                new List<KeyboardButton[]>()
                                                {
                                                    new KeyboardButton[]
                                                    {
                                                         new KeyboardButton("Получить результат!"),

                                                    },
                                                });
                                            await botClient.SendTextMessageAsync(
                                               chat.Id,
                                               $"Это был последений вопрос. Теперь можете узнать свой результат",
                                               replyMarkup: question_11);
                                        }
                                        else if (message.Text == "Получить результат!")
                                        {
                                            var question_12 = new ReplyKeyboardMarkup(
                                                new List<KeyboardButton[]>()
                                                {
                                                    new KeyboardButton[]
                                                    {
                                                         new KeyboardButton("Начать заново"),

                                                    },
                                                });
                                            await botClient.SendTextMessageAsync(
                                               chat.Id,
                                               $"Вы ответили верно на {count_true} вопросов из 10. Это примерно {130 - 10 * (10 - count_true)}",
                                               replyMarkup: question_12);
                                        }
                                        else if (message.Text == "Начать заново")
                                        {
                                            var question_13 = new ReplyKeyboardMarkup(
                                            new List<KeyboardButton[]>()
                                                {
                                                    new KeyboardButton[]
                                                    {
                                                         new KeyboardButton("/start"),

                                                    },
                                                });
                                            await botClient.SendTextMessageAsync(
                                               chat.Id,
                                               $"Попробуйте ещё раз!",
                                               replyMarkup: question_13);
                                        }
                                        else
                                        {
                                            await botClient.SendTextMessageAsync(
                                               chat.Id,
                                               $"Такого ответа не предусмотрено на данный вопрос");
                                        }
                                        return;

                                    }
                            }
                            return;

                        }
                        
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
