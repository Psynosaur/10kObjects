// #include "sortandsum.h"
#include <stdio.h>
#include <string.h>
#include <stdint.h>

char *sortstring(char *str)
{
   char temp;
   int i, j;
   int n = strlen(str);

   for (i = 0; i < n - 1; i++)
   {
      for (j = i + 1; j < n; j++)
      {
         if (str[i] > str[j])
         {
            temp = str[i];
            str[i] = str[j];
            str[j] = temp;
         }
      }
   }

   return str;
}

int sumOfDigits(char *str)
{
   int count, sum = 0;
   for (count = 0; str[count] != '\0'; count++)
   {
      if ((str[count] >= '1') && (str[count] <= '9'))
      {
         sum += (str[count] - '0');
      }
   }
   return sum;
}

uint32_t __stdcall stringSortOut(/*[out]*/ char *lpBuffer, /*[in]*/ uint32_t uSize, /*[in]*/ char *szReturnString)
{
   //   const char szReturnString[] = "Hello World";
   char *temp = sortstring(szReturnString);
   const uint32_t uiStringLength = strlen(temp);

   if (uSize >= (uiStringLength + 1))
   {
      strcpy(lpBuffer, temp);
      // Return the number of characters copied.
      return uiStringLength;
   }
   else
   {
      // Return the required size
      // (including the terminating NULL character).
      return uiStringLength + 1;
   }
}