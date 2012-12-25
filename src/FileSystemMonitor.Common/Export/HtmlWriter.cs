using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileSystemMonitor.Common.Export
{
    public class HtmlWriter : IDisposable
    {
        private const int DEFAULT_INDENT_SIZE = 5;
        private const bool DEFAULT_TAB_CHARACTER = false;
        private const string ATTRIBUTE_MASK = " {0}=\"{1}\"";
        private const string START_TAG_MASK = "<{0}{1}>";
        private const string SINGLE_TAG_MASK = "<{0}{1}>";
        private const string SINGLE_XHTML_TAG_MASK = "<{0}{1} />";
        private const string END_TAG_MASK = "</{0}>";
        private const char TAB_CHARACTER = '\t';
        private const char WHITESPACE_CHARACTER = ' ';
        private const string HTML_WHITESPACE = "&nbsp;";

        private readonly string fileName;
        private readonly Stack<string> elementStack;
        private int indentSize;
        private int indentDepth;
        private bool useTabCharacter;
        private bool useIndentation;
        private StreamWriter streamWriter;
        private bool isOpened;

        public bool IsOpened
        {
            get { return isOpened; }
            set { isOpened = value; }
        }

        public int IndentSize
        {
            get { return indentSize; }
            set { indentSize = value; }
        }

        public bool UseTabCharacter
        {
            get { return useTabCharacter; }
            set { useTabCharacter = value; }
        }

        public int IndentDepth
        {
            get { return indentDepth; }
        }

        public bool UseIndentation
        {
            get { return useIndentation; }
            set { useIndentation = value; }
        }

        public static string HtmlWhitespace
        {
            get { return HTML_WHITESPACE; }
        }

        public HtmlWriter(string fileName)
            : this(fileName, DEFAULT_INDENT_SIZE, DEFAULT_TAB_CHARACTER)
        {
            useIndentation = false;
        }

        public HtmlWriter(string fileName, int indentSize, bool useTabCharacter)
        {
            this.fileName = fileName;
            this.indentSize = indentSize;
            this.useTabCharacter = useTabCharacter;
            elementStack = new Stack<string>();
            indentDepth = 0;
            streamWriter = null;
        }

        public void Open()
        {
            streamWriter = new StreamWriter(fileName, false, Encoding.UTF8);
            IsOpened = true;
        }

        public void Close()
        {
            streamWriter.Close();
            IsOpened = false;
        }

        public void WriteStartElement(string elementName)
        {
            WriteIndenter();
            WriteStringToStream(string.Format(START_TAG_MASK, elementName, string.Empty));
            elementStack.Push(elementName);
            indentDepth++;
        }

        public void WriteStartElement(string elementName, params object[] attributeNameValuePairs)
        {
            WriteIndenter();
            StringBuilder attributeBuilder = new StringBuilder(string.Empty);
            for (int i = 0; i < attributeNameValuePairs.Length; i += 2)
            {
                attributeBuilder.AppendFormat(ATTRIBUTE_MASK, attributeNameValuePairs[i], attributeNameValuePairs[i + 1]);
            }
            WriteStringToStream(string.Format(START_TAG_MASK, elementName, attributeBuilder));
            elementStack.Push(elementName);
            indentDepth++;
        }

        public void WriteSingleTagElement(string elementName, bool useXhtmlStyle, params object[] attributeNameValuePairs)
        {
            WriteIndenter();
            StringBuilder attributeBuilder = new StringBuilder(string.Empty);
            for (int i = 0; i < attributeNameValuePairs.Length; i += 2)
            {
                if (i < attributeNameValuePairs.Length - 1)
                {
                    attributeBuilder.AppendFormat(ATTRIBUTE_MASK, attributeNameValuePairs[i], attributeNameValuePairs[i + 1]);
                }
            }
            WriteStringToStream
                (
                string.Format
                    (
                    (useXhtmlStyle ? SINGLE_TAG_MASK : SINGLE_XHTML_TAG_MASK),
                    elementName,
                    attributeBuilder
                    )
                );
        }

        public void WriteText(string text)
        {
            WriteIndenter();
            WriteStringToStream(text);
        }

        public void WriteEndElement()
        {
            string currentElement = elementStack.Pop();
            indentDepth--;
            WriteIndenter();
            WriteStringToStream(string.Format(END_TAG_MASK, currentElement));
        }

        private void WriteStringToStream(string value)
        {
            streamWriter.Write(value);
        }

        private void WriteIndenter()
        {
            if (!useIndentation)
            {
                return;
            }

            string indentationString = Environment.NewLine;
            if (useTabCharacter)
            {
                indentationString += string.Empty.PadLeft(indentDepth, TAB_CHARACTER);
            }
            else
            {
                indentationString += string.Empty.PadLeft(indentDepth * indentSize, WHITESPACE_CHARACTER);
            }
            WriteStringToStream(indentationString);
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (IsOpened)
            {
                Close();
            }
            streamWriter.Dispose();
        }

        #endregion
    }
}