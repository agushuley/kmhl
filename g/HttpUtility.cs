using System;
using System.Collections.Generic;
using System.Text;

namespace g {
    public class HttpUtility {
        private class UrlDecoder {
            internal UrlDecoder(int bufferSize, Encoding encoding) {
                this._bufferSize = bufferSize;
                this._encoding = encoding;
                this._charBuffer = new char[bufferSize];
            }

            internal void AddByte(byte b) {
                if (this._byteBuffer == null) {
                    this._byteBuffer = new byte[this._bufferSize];
                }
                this._byteBuffer[this._numBytes++] = b;
            }

            internal void AddChar(char ch) {
                if (this._numBytes > 0) {
                    this.FlushBytes();
                }
                this._charBuffer[this._numChars++] = ch;
            }
            private void FlushBytes() {
                if (this._numBytes > 0) {
                    this._numChars += this._encoding.GetChars(this._byteBuffer, 0, this._numBytes, this._charBuffer, this._numChars);
                    this._numBytes = 0;
                }
            }

            internal string GetString() {
                if (this._numBytes > 0) {
                    this.FlushBytes();
                }
                if (this._numChars > 0) {
                    return new string(this._charBuffer, 0, this._numChars);
                }
                return string.Empty;
            }



            // Fields
            private int _bufferSize;
            private byte[] _byteBuffer;
            private char[] _charBuffer;
            private Encoding _encoding;
            private int _numBytes;
            private int _numChars;
        }

        public static string UrlDecode(string str) {
            if (str == null) {
                return null;
            }
            return HttpUtility.UrlDecode(str, Encoding.UTF8);
        }

        public static string UrlDecode(string str, Encoding e) {
            if (str == null) {
                return null;
            }
            return HttpUtility.UrlDecodeStringFromStringInternal(str, e);
        }



        private static string UrlDecodeStringFromStringInternal(string s, Encoding e) {
            int num1 = s.Length;
            HttpUtility.UrlDecoder decoder1 = new HttpUtility.UrlDecoder(num1, e);
            for (int num2 = 0; num2 < num1; num2++) {
                char ch1 = s[num2];
                if (ch1 == '+') {
                    ch1 = ' ';
                }
                else if ((ch1 == '%') && (num2 < (num1 - 2))) {
                    if ((s[num2 + 1] == 'u') && (num2 < (num1 - 5))) {
                        int num3 = HttpUtility.HexToInt(s[num2 + 2]);
                        int num4 = HttpUtility.HexToInt(s[num2 + 3]);
                        int num5 = HttpUtility.HexToInt(s[num2 + 4]);
                        int num6 = HttpUtility.HexToInt(s[num2 + 5]);
                        if (((num3 < 0) || (num4 < 0)) || ((num5 < 0) || (num6 < 0))) {
                            goto Label_0106;
                        }
                        ch1 = (char)((ushort)((((num3 << 12) | (num4 << 8)) | (num5 << 4)) | num6));
                        num2 += 5;
                        decoder1.AddChar(ch1);
                        goto Label_0120;
                    }
                    int num7 = HttpUtility.HexToInt(s[num2 + 1]);
                    int num8 = HttpUtility.HexToInt(s[num2 + 2]);
                    if ((num7 >= 0) && (num8 >= 0)) {
                        byte num9 = (byte)((num7 << 4) | num8);
                        num2 += 2;
                        decoder1.AddByte(num9);
                        goto Label_0120;
                    }
                }
            Label_0106:
                if ((ch1 & 0xff80) == '\0') {
                    decoder1.AddByte((byte)ch1);
                }
                else {
                    decoder1.AddChar(ch1);
                }
            Label_0120: ;
            }
            return decoder1.GetString();
        }

        private static int HexToInt(char h) {
            if ((h >= '0') && (h <= '9')) {
                return (h - '0');
            }
            if ((h >= 'a') && (h <= 'f')) {
                return ((h - 'a') + '\n');
            }
            if ((h >= 'A') && (h <= 'F')) {
                return ((h - 'A') + '\n');
            }
            return -1;
        }

        public static string UrlEncode(string str) {
            if (str == null) {
                return null;
            }
            return HttpUtility.UrlEncode(str, Encoding.UTF8);
        }

        public static string UrlEncode(string str, Encoding e) {
            if (str == null) {
                return null;
            }
            byte[] buff = HttpUtility.UrlEncodeToBytes(str, e);
            return Encoding.ASCII.GetString(buff, 0, buff.Length);
        }

        public static byte[] UrlEncodeToBytes(string str) {
            if (str == null) {
                return null;
            }
            return HttpUtility.UrlEncodeToBytes(str, Encoding.UTF8);
        }

        public static byte[] UrlEncodeToBytes(string str, Encoding e) {
            if (str == null) {
                return null;
            }
            byte[] buffer1 = e.GetBytes(str);
            return HttpUtility.UrlEncodeBytesToBytesInternal(buffer1, 0, buffer1.Length, false);
        }

        private static byte[] UrlEncodeBytesToBytesInternal(byte[] bytes, int offset, int count, bool alwaysCreateReturnValue) {
            int num1 = 0;
            int num2 = 0;
            for (int num3 = 0; num3 < count; num3++) {
                char ch1 = (char)bytes[offset + num3];
                if (ch1 == ' ') {
                    num1++;
                }
                else if (!HttpUtility.IsSafe(ch1)) {
                    num2++;
                }
            }
            if ((!alwaysCreateReturnValue && (num1 == 0)) && (num2 == 0)) {
                return bytes;
            }
            byte[] buffer1 = new byte[count + (num2 * 2)];
            int num4 = 0;
            for (int num5 = 0; num5 < count; num5++) {
                byte num6 = bytes[offset + num5];
                char ch2 = (char)num6;
                if (HttpUtility.IsSafe(ch2)) {
                    buffer1[num4++] = num6;
                }
                else if (ch2 == ' ') {
                    buffer1[num4++] = 0x2b;
                }
                else {
                    buffer1[num4++] = 0x25;
                    buffer1[num4++] = (byte)HttpUtility.IntToHex((num6 >> 4) & 15);
                    buffer1[num4++] = (byte)HttpUtility.IntToHex(num6 & 15);
                }
            }
            return buffer1;
        }

        private static bool IsSafe(char ch) {
            if ((((ch >= 'a') && (ch <= 'z')) || ((ch >= 'A') && (ch <= 'Z'))) || ((ch >= '0') && (ch <= '9'))) {
                return true;
            }
            switch (ch) {
                case '\'':
                case '(':
                case ')':
                case '*':
                case '-':
                case '.':
                case '_':
                case '!':
                    return true;
            }
            return false;
        }

        private static char IntToHex(int n) {
            if (n <= 9) {
                return (char)((ushort)(n + 0x30));
            }
            return (char)((ushort)((n - 10) + 0x61));
        }
    }
}
