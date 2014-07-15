using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



class morse
{

	private Dictionary<char, String> morse_lib;
	private Dictionary<String, char> reverse_lib;

	private void set_lib_alpha()
	{
		morse_lib = new Dictionary<char, String>();

		//add alphas
		 morse_lib.Add(' ',"  ");//a space in text is equal to 2 in morse
		 morse_lib.Add('A',".-");
		 morse_lib.Add('B',"-...");
		 morse_lib.Add('C',"-.-.");
		 morse_lib.Add('D',"-..");
		 morse_lib.Add('E',".");
		 morse_lib.Add('F',"..-.");
		 morse_lib.Add('G',"--.");
		 morse_lib.Add('H',"....");
		 morse_lib.Add('I',"..");
		 morse_lib.Add('J',".---");
		 morse_lib.Add('K',"-.-");
		 morse_lib.Add('L',".-..");
		 morse_lib.Add('M',"--");
		 morse_lib.Add('N',"-.");
		 morse_lib.Add('O',"---");
		 morse_lib.Add('P',".--.");
		 morse_lib.Add('Q',"--.-");
		 morse_lib.Add('R',".-.");
		 morse_lib.Add('S',"...");
		 morse_lib.Add('T',"-");
		 morse_lib.Add('U',"..-");
		 morse_lib.Add('V',"...-");
		 morse_lib.Add('W',".--");
		 morse_lib.Add('X',"-..-");
		 morse_lib.Add('Y',"-.--");
		 morse_lib.Add('Z',"--..");

		 //Add numeric
		 morse_lib.Add('0',"-----");
		 morse_lib.Add('1',".----");
		 morse_lib.Add('2',"..---");
		 morse_lib.Add('3',"...--");
		 morse_lib.Add('4',"....-");
		 morse_lib.Add('5',".....");
		 morse_lib.Add('6',"-....");
		 morse_lib.Add('7',"--...");
		 morse_lib.Add('8',"---..");
		 morse_lib.Add('9',"----.");
	}

	private void prompt()
	{
		Console.Write("Decode Morse = 2");
		Console.Write(" / Encode Morse = 1\n");
		Console.WriteLine("Enter Input Type ('exit' to quit): "); // Prompt
	    string line = Console.ReadLine(); // Get string from user
	    

	    if (line == "1"){
	    	Console.WriteLine("\n-*-*-*-*-*-*-*-*-*-*-*-*-*-\n");
	    	encode();
	    } else if (line == "2"){
	    	Console.WriteLine("\n*-*-*-*-*-*-*-*-*-*-*-*-*-*\n");
	    	decode();
	    } else if (line == "exit"){
	    	Console.Clear();
			return;
	    } else {
	    	Console.Clear();
	    	Console.WriteLine("\n*PLEASE ENTER VALID ENTRY*\n");
	    	prompt();
	    }
	}

	private void encode()
	{
		Console.WriteLine("Enter string to encode to Morse: "); // Prompt
	    string line = Console.ReadLine(); // Get string from user

		Char[] letters = line.ToCharArray();

		StringBuilder morse = new StringBuilder();

		for (int i = 0; i < letters.Length; i++)
		{
			Char cur = letters[i];
			if(cur == ' ')
			{
				morse.Append("   ");
			} else {
				morse.Append(morse_lib[cur]);
				morse.Append(" ");
			}
			
		}

		Console.Clear();

		Console.WriteLine(line);
		Console.Write(" in Morse is: ");
		Console.Write(morse);

		prompt();
	}

	//String must contain two spaces between words
	//and a single space between letters
	//ex: SOS SOS = ... --- ...  ... --- ...
	private void decode()
	{
		Console.WriteLine("Enter Morse to decode: "); // Prompt
	    string line = Console.ReadLine(); // Get string from user

	    Char[] letters = line.ToCharArray();

		StringBuilder morse = new StringBuilder();
		StringBuilder english = new StringBuilder();

		for (int i = 0; i < letters.Length; i++)
		{
			//if cur != ' ' next is not, append to morse
			char cur = letters[i];
			char cur_next = ' ';

			if( i <= letters.Length-2)
			{
				cur_next = letters[i+1];//look ahead one char
			}
			
			if(cur != ' ')
			{
				morse.Append(cur);

			} else if (cur == ' ' && cur_next != ' '){//single char
				
				english.Append(reverse_lib[morse.ToString()]);
				Console.WriteLine();
				Console.WriteLine();
				morse = new StringBuilder();

			} else if (cur == ' ' && cur_next == ' '){//

				english.Append(reverse_lib[morse.ToString()]);
				english.Append(' ');
				i++;
				morse = new StringBuilder();
			} else if (cur != ' ' && (i+1)==letters.Length){
				english.Append(reverse_lib[morse.ToString()]);
			}
			
		}

		english.Append(reverse_lib[morse.ToString()]);//grab last morse char

		Console.Clear();

		Console.Write(line);
		Console.Write(" in English is: ");
		Console.Write(english + "\n");

		prompt();
	}

	private void convert_morse(String morse)
	{

	}

	private void set_reverse()
	{
		reverse_lib = morse_lib.ToDictionary(x => x.Value, x => x.Key);

		/*= morse_lib.Values.SelectMany( v => v ).Distinct();

		foreach( var s in reverse_lib )
		{
		   var vals = morse_lib.Keys.Where( k => morse_lib[k].Contains(s) );
		   reverse_lib.Add( s, vals.ToList() );
		}*/
	}
	
	static void Main(string[] args)
	{
		Console.Clear();

		morse m = new morse();

		m.set_lib_alpha();
		m.set_reverse();
		m.prompt();

		return;
	}
}
