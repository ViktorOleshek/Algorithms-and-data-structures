#include "laba1.h"

using namespace System;
using namespace System::Windows::Forms;
using namespace ACD;

[STAThreadAttribute]

int main(array<String ^> ^args)
{
  Application::EnableVisualStyles();
  Application::SetCompatibleTextRenderingDefault(false);
  ACD::laba1 form;
  Application::Run(% form);
  return 0;
}