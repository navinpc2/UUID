using System;
using UUIDContract;

namespace UUIDImplementation
{
    public class UUID : IUUID
    {
        public string FindLongestIncreasingSubsequence(string sequence)
        {
            var inputArray = (sequence ?? "").Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            var lengthInputArray = inputArray.Length;
            
            int? lengthOfMaxSubsequence = null, startIndexOfMaxSubsequence = null, tempLength = null, tempStart = null;
            int? previousElement = null;

            for (var i = 0; i < lengthInputArray; ++i)
            {
                int currentElement;

                if (!int.TryParse(inputArray[i], out currentElement))
                {
                    throw new ArgumentException(string.Concat(inputArray[i], " is invalid integer!"), "input");
                }

                if (previousElement != null)
                {
                    if (currentElement > previousElement)
                    {
                        if (tempStart == null)
                        {
                            tempStart = i - 1;
                        }
                        tempLength = tempLength == null ? 2 : tempLength + 1;
                    }

                    if ((currentElement <= previousElement || i == lengthInputArray - 1) && tempLength != null)
                    {
                        if (lengthOfMaxSubsequence == null || tempLength > lengthOfMaxSubsequence)
                        {
                            lengthOfMaxSubsequence = tempLength;
                            startIndexOfMaxSubsequence = tempStart;
                        }

                        tempStart = tempLength = null;
                    }
                }

                previousElement = currentElement;
            }

            if (lengthOfMaxSubsequence == null)
            {
                return string.Empty;
            }
            else
            {
                return string.Join(separator: ' ', value: inputArray, startIndex: startIndexOfMaxSubsequence.Value, count: lengthOfMaxSubsequence.Value);
            }
        }
    }
}
