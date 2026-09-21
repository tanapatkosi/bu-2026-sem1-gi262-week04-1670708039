using UnityEngine;
using System.Collections.Generic;
 
namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            // AS01_CountWords();
            // AS02_CountNumber();
            // AS03_CheckValidBrackets();
            // AS04_PrintReverseLinkedList();
            // AS05_FindMiddleElement();
            // AS06_MergeDictionaries();
            // AS07_RemoveDuplicatesFromLinkedList();
            // AS08_TopFrequentNumber();
            // AS09_PlayerInventory();
            // AS10_GameEventQueue();
            // AS11_PlayerStatsTracker();
        }
 
 
        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;
 
        public void AS01_CountWords()
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
 
            for (int i = 0; i < as01Words.Length; i++)
            {
                if (words.ContainsKey(as01Words[i]))
                {
                    words[as01Words[i]]++;
                }
                else
                {
                    words.Add(as01Words[i], 1);
                }
            }
 
            foreach (KeyValuePair<string, int> item in words)
            {
                Debug.Log("word: '" + item.Key + "' count: " + item.Value);
            }
        }
 
 
        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;
 
        public void AS02_CountNumber()
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
 
            for (int i = 0; i < as02Numbers.Length; i++)
            {
                if (numbers.ContainsKey(as02Numbers[i]))
                {
                    numbers[as02Numbers[i]]++;
                }
                else
                {
                    numbers.Add(as02Numbers[i], 1);
                }
            }
 
            foreach (KeyValuePair<int, int> item in numbers)
            {
                Debug.Log("number: " + item.Key + " count: " + item.Value);
            }
        }
 
 
        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;
 
        public void AS03_CheckValidBrackets()
        {
            Dictionary<char, char> brackets = new Dictionary<char, char>();
 
            brackets.Add('(', ')');
            brackets.Add('[', ']');
            brackets.Add('{', '}');
 
            LinkedList<char> stack = new LinkedList<char>();
 
            for (int i = 0; i < as03Input.Length; i++)
            {
                char current = as03Input[i];
 
                if (brackets.ContainsKey(current))
                {
                    stack.AddLast(current);
                }
                else if (current == ')' || current == ']' || current == '}')
                {
                    if (stack.Count == 0)
                    {
                        Debug.Log("Invalid");
                        return;
                    }
 
                    char open = stack.Last.Value;
 
                    if (brackets[open] != current)
                    {
                        Debug.Log("Invalid");
                        return;
                    }
 
                    stack.RemoveLast();
                }
            }
 
            if (stack.Count == 0)
            {
                Debug.Log("Valid");
            }
            else
            {
                Debug.Log("Invalid");
            }
        }
 
 
        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List =
            new IntLinkedListInput();
 
        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();
 
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }
 
            LinkedListNode<int> node = list.Last;
 
            while (node != null)
            {
                Debug.Log(node.Value);
                node = node.Previous;
            }
        }
 
 
        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List =
            new StringLinkedListInput();
 
        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();
 
            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }
 
            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;
 
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
 
            Debug.Log(slow.Value);
        }
 
 
        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary =
            new StringIntDictionaryInput();
 
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary =
            new StringIntDictionaryInput();
 
        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> first =
                as06FirstDictionary.GetDictionary();
 
            Dictionary<string, int> second =
                as06SecondDictionary.GetDictionary();
 
            Dictionary<string, int> result =
                new Dictionary<string, int>();
 
            foreach (KeyValuePair<string, int> item in first)
            {
                result.Add(item.Key, item.Value);
            }
 
            foreach (KeyValuePair<string, int> item in second)
            {
                if (result.ContainsKey(item.Key))
                {
                    result[item.Key] += item.Value;
                }
                else
                {
                    result.Add(item.Key, item.Value);
                }
            }
 
            foreach (KeyValuePair<string, int> item in result)
            {
                Debug.Log("key: " + item.Key + ", value: " + item.Value);
            }
        }
 
 
        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List =
            new IntLinkedListInput();
 
        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();
 
            Dictionary<int, bool> numbers =
                new Dictionary<int, bool>();
 
            LinkedListNode<int> current = list.First;
 
            while (current != null)
            {
                LinkedListNode<int> next = current.Next;
 
                if (numbers.ContainsKey(current.Value))
                {
                    list.Remove(current);
                }
                else
                {
                    numbers.Add(current.Value, true);
                }
 
                current = next;
            }
 
            foreach (int number in list)
            {
                Debug.Log(number);
            }
        }
 
 
        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;
 
        public void AS08_TopFrequentNumber()
        {
            if (as08Numbers == null || as08Numbers.Length == 0)
            {
                Debug.Log("Input array is empty");
                return;
            }
 
            Dictionary<int, int> numbers =
                new Dictionary<int, int>();
 
            for (int i = 0; i < as08Numbers.Length; i++)
            {
                if (numbers.ContainsKey(as08Numbers[i]))
                {
                    numbers[as08Numbers[i]]++;
                }
                else
                {
                    numbers.Add(as08Numbers[i], 1);
                }
            }
 
            int mostNumber = as08Numbers[0];
            int maxCount = numbers[mostNumber];
 
            for (int i = 0; i < as08Numbers.Length; i++)
            {
                int number = as08Numbers[i];
 
                if (numbers[number] > maxCount)
                {
                    mostNumber = number;
                    maxCount = numbers[number];
                }
            }
 
            Debug.Log(mostNumber + " count: " + maxCount);
        }
 
 
        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory =
            new StringIntDictionaryInput();
 
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;
 
        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory =
                as09Inventory.GetDictionary();
 
            if (inventory.ContainsKey(as09ItemName))
            {
                inventory[as09ItemName] += as09Quantity;
            }
            else
            {
                inventory.Add(as09ItemName, as09Quantity);
            }
 
            foreach (KeyValuePair<string, int> item in inventory)
            {
                Debug.Log(item.Key + ": " + item.Value);
            }
        }
 
 
        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue =
            new GameEventLinkedListInput();
 
        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> events =
                as10EventQueue.GetLinkedList();
 
            if (events.Count == 0)
            {
                Debug.Log("Event queue is empty");
                return;
            }
 
            while (events.Count > 0)
            {
                GameEvent current = events.First.Value;
 
                events.RemoveFirst();
 
                Debug.Log("Processing event: " + current.Name);
                Debug.Log("Remaining events in queue: " + events.Count);
 
                if (current.EventType == "enemy")
                {
                    Debug.Log(
                        "Enemy event processed - " + current.Name
                    );
                }
                else if (current.EventType == "powerup")
                {
                    Debug.Log(
                        "Power-up event processed - " + current.Name
                    );
                }
                else if (current.EventType == "level")
                {
                    Debug.Log(
                        "Level event processed - " + current.Name
                    );
                }
            }
        }
 
 
        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats =
            new StringIntDictionaryInput();
 
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;
 
        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> stats =
                as11PlayerStats.GetDictionary();
 
            if (stats.ContainsKey(as11StatName))
            {
                stats[as11StatName] += as11Value;
            }
            else
            {
                stats.Add(as11StatName, as11Value);
            }
 
            Debug.Log(
                "Updated " +
                as11StatName +
                ": " +
                stats[as11StatName]
            );
 
            Debug.Log("Current player statistics:");
 
            foreach (KeyValuePair<string, int> item in stats)
            {
                Debug.Log(item.Key + ": " + item.Value);
            }
        }
    }
}
