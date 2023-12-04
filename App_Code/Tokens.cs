﻿using System.Collections;


/// <summary>
/// Descripción breve de Tokens
/// </summary>
public class Tokens : IEnumerable
{
    private string[] elements;

    public Tokens(string source, char[] delimiters)
    {
        // Parse the string into tokens:
        elements = source.Split(delimiters);
    }

    // IEnumerable Interface Implementation:
    //   Declaration of the GetEnumerator() method 
    //   required by IEnumerable
    public IEnumerator GetEnumerator()
    {
        return new TokenEnumerator(this);
    }

    // Inner class implements IEnumerator interface:
    private class TokenEnumerator : IEnumerator
    {
        private int position = -1;
        private Tokens t;

        public TokenEnumerator(Tokens t)
        {
            this.t = t;
        }

        // Declare the MoveNext method required by IEnumerator:
        public bool MoveNext()
        {
            if (position < t.elements.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Declare the Reset method required by IEnumerator:
        public void Reset()
        {
            position = -1;
        }

        // Declare the Current property required by IEnumerator:
        public object Current
        {
            get
            {
                return t.elements[position];
            }
        }
    }

}
