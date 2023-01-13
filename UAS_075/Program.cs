using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UAS_075;

namespace UAS_075
{
    class Node
    {
        public int NIM;
        public string name;
        public string jeniskelamin;
        public string kelas;
        public string asaldaerah;
        public Node next;
    }
    class List
    {
        Node START;
        public void insert()
        {
            int no;
            string nm, kl, ad, jk;
            Console.Write("Masukan NIM : ");
            no = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukan nama : ");
            nm = Console.ReadLine();
            Console.Write("Masukkan Jenis Kelamin : ");
            jk = Console.ReadLine();
            Console.Write("kelas : ");
            kl = Console.ReadLine();
            Console.Write("asal daerah : ");
            ad = Console.ReadLine();

            Node newNode = new Node();

            newNode.NIM = no;
            newNode.name = nm;
            newNode.jeniskelamin = jk;
            newNode.kelas = kl;
            newNode.asaldaerah = ad;

            if (START == null || no <= START.NIM)
            {
                if ((START != null) && (no == START.NIM))
                {
                    Console.WriteLine("Duplikat nomor induk mahasiswa tidak diperbolehkan");
                    return;
                }
                newNode.next = START;
                START = newNode;
                return;
                Node previous, current;
                previous = START;
                current = START;

                while ((current != null) && (no >= current.NIM))
                {
                    if (no == current.NIM)
                    {
                        Console.WriteLine("\nDuplikat nomor induk mahasiswa tidak diperbolehkan");
                        return;
                    }
                    previous = current;
                    current = current.next;
                }
                newNode.next = current;
                previous.next = newNode;
            }
        }

        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
             previous = current = START;
             while (current != null &&
                 rollNo != current.NIM)
             {
                 previous.next = current;
                 current = current.next;
             }
             return (current != null);
            }
        }
        public void traverse()
        {
           if (listEmpty())
               Console.WriteLine("\nList kosong");
           else
           {
               Console.WriteLine("\nList data siswa : ");
               Console.Write("NIM" + "   " + "Nama" + "    " + "Jenis Kelmain" + "   " + "Kelas" + " Asal Daerah" + "\n");
               Node currentNode;
               for (currentNode = START; currentNode != null; currentNode = currentNode.next)
               {
                   Console.Write(currentNode.NIM + "    " + currentNode.name + "    " + currentNode.jeniskelamin  + "         " + currentNode.kelas + "       " + currentNode.asaldaerah + "      " + "\n");
               }
               Console.WriteLine();
           }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        List obj = new List();
        while (true)
        {
            try
            {
                Console.WriteLine("\nMENU");
                Console.WriteLine("1. Add a record to the list");
                Console.WriteLine("2. View all the records in the list");
                Console.WriteLine("3. Search for a record in the list");
                Console.WriteLine("4. Exit");
                Console.Write("\nEnter your choice (1-4) : ");
                char ch = Convert.ToChar(Console.ReadLine());
                switch (ch)
                {
                    case '1':
                        {
                            obj.insert();
                        }
                        break;
                    case '2':
                        {
                            obj.traverse();
                        }
                        break;
                    case '3':
                        {
                            if (obj.ListEmpty() == true)
                            {
                                Console.WriteLine("\nList is kosong");
                                break;
                            }
                            Node previous, current;
                            previous = current = null;
                            Console.Write("\nmasukan  kota asal yang ingin dicari : ");
                            int num =  Convert.ToInt32(Console.ReadLine());
                            if (obj.Search(num, ref previous, ref current) == false)
                                Console.WriteLine("\nRecord not found");
                            else
                            {
                                Node TH;
                                for (TH = current; TH != null; TH = TH.next)
                                {
                                    Console.WriteLine("\nRecord  found");
                                    Console.WriteLine("\nNIM: " + current.NIM);
                                    Console.WriteLine("\nNAMA : " + current.name);
                                    Console.WriteLine("\nJenis Kelamin: " + current.jk);
                                    Console.WriteLine("\nKelas: " + current.kl);
                                    Console.WriteLine("\nAsal Daerah: " + current.ad);
                                }
                            }
                        }
                        break;
                    case '4':
                        return;
                    default:
                        {
                            Console.WriteLine("\nInvalid Option");
                            break;
                        }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nCheck for for the value entered");
            }
        }
    }
}

