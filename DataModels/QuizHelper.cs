using System;
using System.Collections.Generic;

namespace Quiz_App.DataModels
{
    public class QuizHelper
    {
        List<Question> History;
        List<Question> Geography;
        List<Question> Business;
        List<Question> Programming;
        List<Question> Engineering;
        List<Question> Space;

        public List<Question> GetQuizQuestions(string topic)
        {
            List<Question> QuizList = new List<Question>();

            if( topic == "History")
            {
                InitializeHistory();
                QuizList = History;
            }
            else if (topic == "Space")
            {
                InitializeSpace();
                QuizList = Space;
            }
            else if (topic == "Geography")
            {
                InitializeGeography();
                QuizList = Geography;
            }

            return QuizList;
        }

        public string GetTopicDescription( string topic)
        {

            string topicDescription = "";

            if(topic == "History")
            {
                topicDescription = "History is the study of the past as it is described in written documents. Events occurring before written record are considered prehistory. It is an umbrella term that relates to past events as well as the memory, discovery, collection, organization, presentation, and interpretation of information about these events.";
            }
            else if (topic == "Space")
            {
                topicDescription = "The concept of space is considered to be of fundamental importance to an understanding of the physical universe. However, disagreement continues between philosophers over whether it is itself an entity, a relationship between entities, or part of a conceptual framework.";
            }
            else if (topic == "Geography")
            {
                topicDescription = "Geography is the study of places and the relationships between people and their environments. Geographers explore both the physical properties of Earth's surface and the human societies spread across it.";
            }

            return topicDescription;
        }

        void InitializeHistory()
        {
            History = new List<Question>();
            History.Add(new Question { QuizQuestion = "During which decade was slavery abolished in the United States?", Answer = "1860s", OptionA = "1840s", OptionB = "1850s", OptionC = "1860s", optionD = "1870" });
            History.Add(new Question { QuizQuestion = "During which year did Christopher Columbus first arrive in the Americas?", Answer = "1495", OptionA = "1495", OptionB = "1492", OptionC = "1498", optionD = "1501" });
            History.Add(new Question { QuizQuestion = "Which year was the first edition of FIFA World Cup played", Answer = "1930", OptionA = "1985", OptionB = "1920", OptionC = "1930", optionD = "2002" });
            History.Add(new Question { QuizQuestion = "World War II also known as the Second World War, was a global war that lasted from 1939 to ?", Answer = "1945", OptionA = "1986", OptionB = "1922", OptionC = "1945", optionD = "1939" });
            History.Add(new Question { QuizQuestion = "The assassination of Julius Caesar was the result of a conspiracy by many Roman senators, he was stabbed by?", Answer = "Junius Brutus", OptionA = "Uchenna Nnodim", OptionB = "Cassius Longinus", OptionC = "Junius Brutus", optionD = "Orsa Kemi" });

        }

        void InitializeSpace()
        {
            Space = new List<Question>();
            Space.Add(new Question { QuizQuestion = "Who was the first man to ever walk on the Moon?", Answer = "Niel Armstrong", OptionA = "Uchenna Nnodim", OptionB = "Niel Armstrong", OptionC = "Benjamin Franklin", optionD = "Pele Pele" });
            Space.Add(new Question { QuizQuestion = "The coldest and farthest Planet from the Sun is ?", Answer = "Pluto", OptionA = "Earth", OptionB = "Pluto", OptionC = "Neptune", optionD = "Saturn" });
            Space.Add(new Question { QuizQuestion = "The galaxy that contains Solar System which Earth belongs to is called what?", Answer = "Milky Way", OptionA = "Chocolate Path", OptionB = "Phantom Zone", OptionC = "Milky Way", optionD = "Solar Container" });
            Space.Add(new Question { QuizQuestion = "How many days does it take the Earth to complete her orbit", Answer = "365 Days", OptionA = "365 Days", OptionB = "30 Days", OptionC = "272 Days", optionD = "None of the Above" });
            Space.Add(new Question { QuizQuestion = "An explosion which leads to gigantic explosion throwing star's outer layers are thrown out is called", Answer = "Supernova", OptionA = "Black hole", OptionB = "Double ring", OptionC = "Massive Explosion", optionD = "Supernova" });

        }

        void InitializeGeography()
        {
            Geography = new List<Question>();
            Geography.Add(new Question { QuizQuestion = "What is the largest country in the world (by Area)?", Answer = "Russia", OptionA = "Russia", OptionB = "Canada", OptionC = "United Sates", optionD = "China" });
            Geography.Add(new Question { QuizQuestion = "Which of the following countries does NOT have a population exceeding 200 million?", Answer = "Nigeria", OptionA = "Brazil", OptionB = "Indonesia", OptionC = "Pakistan", optionD = "Nigeria" });
            Geography.Add(new Question { QuizQuestion = "Muscat is the capital of which country?", Answer = "Oman", OptionA = "Oman", OptionB = "Jordan", OptionC = "Yemen", optionD = "Bahrain" });
            Geography.Add(new Question { QuizQuestion = "Which is the world's smallest continent (by area)?", Answer = "Oceania", OptionA = "Oceania", OptionB = "Antractica", OptionC = "South America", optionD = "Europe" });
            Geography.Add(new Question { QuizQuestion = "Which of the following countries is NOT a member state of the European Union?", Answer = "Norway", OptionA = "Finland", OptionB = "Sweden", OptionC = "Norway", optionD = "Denmark" });
        }

        void InitializeBusiness()
        {
            Business = new List<Question>();
            Business.Add(new Question { QuizQuestion = "Business finance can come from either internal or external sources.Which of the following is an internal source of finance?", Answer = "Selling assets", OptionA = "A loan from a bank", OptionB = "An overdraft", OptionC = "Selling assets", optionD = "A stock market flotation" });
            Business.Add(new Question { QuizQuestion = "A business breaks even at the level of output where", Answer = "Total revenue = total costs", OptionA = "Total profits = total costs", OptionB = "Fixed costs = total revenue", OptionC = "Variable costs = fixed costs", optionD = "Total revenue = total costs." });
            Business.Add(new Question { QuizQuestion = "Which of the following is most likely to be a barrier to effective communication between workers?", Answer = "De-stocking", OptionA = "Poor customer service", OptionB = "Pressure groups", OptionC = "De-stocking", optionD = "Use of jargon" });
            Business.Add(new Question { QuizQuestion = "", Answer = "", OptionA = "", OptionB = "", OptionC = "", optionD = "" });
            Business.Add(new Question { QuizQuestion = "", Answer = "", OptionA = "", OptionB = "", OptionC = "", optionD = "" });
            Business.Add(new Question { QuizQuestion = "", Answer = "", OptionA = "", OptionB = "", OptionC = "", optionD = "" });
        }


        void InitializeProgramming()
        {
            Programming = new List<Question>();
            Programming.Add(new Question { QuizQuestion = "", Answer = "", OptionA = "", OptionB = "", OptionC = "", optionD = "" });
            Programming.Add(new Question { QuizQuestion = "", Answer = "", OptionA = "", OptionB = "", OptionC = "", optionD = "" });
            Programming.Add(new Question { QuizQuestion = "", Answer = "", OptionA = "", OptionB = "", OptionC = "", optionD = "" });
            Programming.Add(new Question { QuizQuestion = "", Answer = "", OptionA = "", OptionB = "", OptionC = "", optionD = "" });
            Programming.Add(new Question { QuizQuestion = "", Answer = "", OptionA = "", OptionB = "", OptionC = "", optionD = "" });
            Programming.Add(new Question { QuizQuestion = "", Answer = "", OptionA = "", OptionB = "", OptionC = "", optionD = "" });

        }

        void InitializeEngineering()
        {
            Engineering = new List<Question>();
            Engineering.Add(new Question { QuizQuestion = "", Answer = "", OptionA = "", OptionB = "", OptionC = "", optionD = "" });
            Engineering.Add(new Question { QuizQuestion = "", Answer = "", OptionA = "", OptionB = "", OptionC = "", optionD = "" });
            Engineering.Add(new Question { QuizQuestion = "", Answer = "", OptionA = "", OptionB = "", OptionC = "", optionD = "" });
            Engineering.Add(new Question { QuizQuestion = "", Answer = "", OptionA = "", OptionB = "", OptionC = "", optionD = "" });
            Engineering.Add(new Question { QuizQuestion = "", Answer = "", OptionA = "", OptionB = "", OptionC = "", optionD = "" });

        }
    }
}
