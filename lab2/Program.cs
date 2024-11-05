using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Professor
{
    public string degree;
    public string title;
    public string position;
    public string diploma;

    public Professor(string degree, string title, string position, string diploma)
    {
        this.degree = degree;
        this.title = title;
        this.position = position;
        this.diploma = diploma;
    }

    public override string ToString()
    {
        return degree + ", " + title + ", " + position + ", " + diploma;
    }

}

class ProfessorsIndex
{
    Dictionary<string, List<string>> degreeIndex = new Dictionary<string, List<string>>();
    Dictionary<string, List<string>> titleIndex = new Dictionary<string, List<string>>();
    Dictionary<string, List<string>> positionIndex = new Dictionary<string, List<string>>();
    Dictionary<string, List<string>> diplomaIndex = new Dictionary<string, List<string>>();
    List<Professor> professor = new List<Professor>();
    public void AddProfessor(Professor professor)
    {
        int bookId = this.professor.Count;
        this.professor.Add(professor);

        degreeIndex.TryAdd(professor.degree, new List<string>());
        degreeIndex[professor.degree].Add(professor.degree);
        titleIndex.TryAdd(professor.title, new List<string>());
        titleIndex[professor.title].Add(professor.title);
        positionIndex.TryAdd(professor.position, new List<string>());
        positionIndex[professor.position].Add(professor.position);
        diplomaIndex.TryAdd(professor.diploma, new List<string>());
        diplomaIndex[professor.diploma].Add(professor.diploma);
    }

    public void LoadBooksFromFile(string filePath)
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
            if (sr != null)
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(", ");
                    if (data.Length == 4)
                    {
                        string degree = data[0];
                        string title = data[1];
                        string position = data[2];
                        string diploma = data[3];
                        AddProfessor(new Professor(degree, title, position, diploma));
                    }
                }
            } else
            {
                Console.WriteLine("Cannot read data from file.");
            }
        }
    }

    public List<Professor> SearchProfessors(Dictionary<string, string> criteria, string oper)
    {
        HashSet<string> resultSet = new HashSet<string>();

        if (oper.Equals("AND", StringComparison.OrdinalIgnoreCase))
    {
            bool firstCriteria = true;
            foreach (var entry in criteria)
            {
                string key = entry.Key;
                string value = entry.Value;
                HashSet<string> currentSet = new HashSet<string>();
                if (key.Equals("degree", StringComparison.OrdinalIgnoreCase))
                {
                    if (degreeIndex.ContainsKey(value))
                    {
                        currentSet.UnionWith(degreeIndex[value]);
                    };
                }
                else if (key.Equals("title", StringComparison.OrdinalIgnoreCase))
                {
                    if (titleIndex.ContainsKey(value))
                    {
                        currentSet.UnionWith(titleIndex[value]);
                    };
                }
                else if (key.Equals("position", StringComparison.OrdinalIgnoreCase))
                {
                    if (positionIndex.ContainsKey(value))
                    {
                        currentSet.UnionWith(positionIndex[value]);
                    };
                }
                else if (key.Equals("diploma", StringComparison.OrdinalIgnoreCase))
                {
                    if (diplomaIndex.ContainsKey(value))
                    {
                        currentSet.UnionWith(diplomaIndex[value]);
                    };
                }

                if (firstCriteria)
                {
                    resultSet = currentSet;
                    firstCriteria = false;
                }
                else
                {
                    resultSet.IntersectWith(currentSet);
                }
            }
        }
    else if (oper.Equals("OR", StringComparison.OrdinalIgnoreCase))
    {
            foreach (var entry in criteria)
            {
                string key = entry.Key;
                string value = entry.Value;
                if (key.Equals("degree", StringComparison.OrdinalIgnoreCase))
                {
                    if (degreeIndex.ContainsKey(value))
                    {
                        resultSet.UnionWith(degreeIndex[value]);
                    };
                }
                else if (key.Equals("title", StringComparison.OrdinalIgnoreCase))
                {
                    if (titleIndex.ContainsKey(value))
                    {
                        resultSet.UnionWith(titleIndex[value]);
                    };
                }
                else if (key.Equals("position", StringComparison.OrdinalIgnoreCase))
                {
                    if (positionIndex.ContainsKey(value))
                    {
                        resultSet.UnionWith(positionIndex[value]);
                    };
                }
                else if (key.Equals("diploma", StringComparison.OrdinalIgnoreCase) && diplomaIndex.ContainsKey(value))
                {
                        resultSet.UnionWith(diplomaIndex[value]);
                }
            }
        }

        List<Professor> professorList = resultSet.Select(id => professor[int.Parse(id)]).ToList();
        return professorList;
    }

}

class MainClass
{
    public static void Main(string[] args)
    {
        ProfessorsIndex profIndex = new ProfessorsIndex();
        profIndex.LoadBooksFromFile("list_of_professors.txt");
        Dictionary<string, string> criteria = new Dictionary<string, string>();

        Console.WriteLine("Enter degree, title, position, diploma to search:");

        while (true)
        {
            Console.Write("Criteria (or 'done'): ");
            string key = Console.ReadLine();
            if (key.Equals("done", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            Console.Write("Value: ");
            string value = Console.ReadLine();
            criteria.Add(key, value);
        };

        Console.Write("AND or OR: ");
        string oper = Console.ReadLine();

        List<Professor> results = profIndex.SearchProfessors(criteria, oper);
        if (results.Count == 0)
        {
            Console.WriteLine("Unable to find professors with current search options.");
        } else
        {
            Console.WriteLine("Results: ");
            foreach (Professor prof in results)
            {
                Console.WriteLine(prof);
            }
        }

    }
}