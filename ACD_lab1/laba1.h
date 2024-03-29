#pragma once

namespace ACD {

	using namespace System;
	using namespace System::Diagnostics;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для laba1
	/// </summary>
	public ref class laba1 : public System::Windows::Forms::Form
	{
	public:
		laba1(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~laba1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Button ^button1;
	private: System::Windows::Forms::TextBox ^TextBoxElement;
	private: System::Windows::Forms::TextBox ^TextBox_Massive;
	private: System::Windows::Forms::Button ^button_Exit;
	private: System::Windows::Forms::Button ^button2;
	private: System::Windows::Forms::TextBox ^textBox_SortingTime;
	private: System::Windows::Forms::Button ^button3;
	private: System::Windows::Forms::TextBox ^TextBox_CheckingResult;


	private: System::Windows::Forms::Button ^button4;





	protected:


	private:
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
		  this->button1 = (gcnew System::Windows::Forms::Button());
		  this->TextBoxElement = (gcnew System::Windows::Forms::TextBox());
		  this->TextBox_Massive = (gcnew System::Windows::Forms::TextBox());
		  this->button_Exit = (gcnew System::Windows::Forms::Button());
		  this->button2 = (gcnew System::Windows::Forms::Button());
		  this->textBox_SortingTime = (gcnew System::Windows::Forms::TextBox());
		  this->button3 = (gcnew System::Windows::Forms::Button());
		  this->TextBox_CheckingResult = (gcnew System::Windows::Forms::TextBox());
		  this->button4 = (gcnew System::Windows::Forms::Button());
		  this->SuspendLayout();
		  // 
		  // button1
		  // 
		  this->button1->Location = System::Drawing::Point(506, 12);
		  this->button1->Name = L"button1";
		  this->button1->Size = System::Drawing::Size(125, 36);
		  this->button1->TabIndex = 0;
		  this->button1->Text = L"Create";
		  this->button1->UseVisualStyleBackColor = true;
		  this->button1->Click += gcnew System::EventHandler(this, &laba1::button_CreateArray);
		  // 
		  // TextBoxElement
		  // 
		  this->TextBoxElement->Location = System::Drawing::Point(322, 12);
		  this->TextBoxElement->Multiline = true;
		  this->TextBoxElement->Name = L"TextBoxElement";
		  this->TextBoxElement->Size = System::Drawing::Size(167, 36);
		  this->TextBoxElement->TabIndex = 1;
		  this->TextBoxElement->TextChanged += gcnew System::EventHandler(this, &laba1::textBox1_TextChanged);
		  // 
		  // TextBox_Massive
		  // 
		  this->TextBox_Massive->Location = System::Drawing::Point(12, 12);
		  this->TextBox_Massive->Multiline = true;
		  this->TextBox_Massive->Name = L"TextBox_Massive";
		  this->TextBox_Massive->ShortcutsEnabled = false;
		  this->TextBox_Massive->Size = System::Drawing::Size(255, 441);
		  this->TextBox_Massive->TabIndex = 2;
		  this->TextBox_Massive->TextChanged += gcnew System::EventHandler(this, &laba1::textBox1_TextChanged_1);
		  // 
		  // button_Exit
		  // 
		  this->button_Exit->Location = System::Drawing::Point(543, 415);
		  this->button_Exit->Name = L"button_Exit";
		  this->button_Exit->Size = System::Drawing::Size(88, 38);
		  this->button_Exit->TabIndex = 3;
		  this->button_Exit->Text = L"Exit";
		  this->button_Exit->UseVisualStyleBackColor = true;
		  this->button_Exit->Click += gcnew System::EventHandler(this, &laba1::funcButton_Exit);
		  // 
		  // button2
		  // 
		  this->button2->Location = System::Drawing::Point(506, 71);
		  this->button2->Name = L"button2";
		  this->button2->Size = System::Drawing::Size(125, 38);
		  this->button2->TabIndex = 4;
		  this->button2->Text = L"Sort";
		  this->button2->UseVisualStyleBackColor = true;
		  this->button2->Click += gcnew System::EventHandler(this, &laba1::button_SortArray);
		  // 
		  // textBox_SortingTime
		  // 
		  this->textBox_SortingTime->Location = System::Drawing::Point(322, 71);
		  this->textBox_SortingTime->Multiline = true;
		  this->textBox_SortingTime->Name = L"textBox_SortingTime";
		  this->textBox_SortingTime->Size = System::Drawing::Size(167, 37);
		  this->textBox_SortingTime->TabIndex = 5;
		  this->textBox_SortingTime->Text = L"Time: ";
		  this->textBox_SortingTime->TextChanged += gcnew System::EventHandler(this, &laba1::func_textBox_SortingTime);
		  // 
		  // button3
		  // 
		  this->button3->Location = System::Drawing::Point(506, 180);
		  this->button3->Name = L"button3";
		  this->button3->Size = System::Drawing::Size(125, 37);
		  this->button3->TabIndex = 6;
		  this->button3->Text = L"Print";
		  this->button3->UseVisualStyleBackColor = true;
		  this->button3->Click += gcnew System::EventHandler(this, &laba1::button_PrintArray);
		  // 
		  // TextBox_CheckingResult
		  // 
		  this->TextBox_CheckingResult->Location = System::Drawing::Point(322, 128);
		  this->TextBox_CheckingResult->Multiline = true;
		  this->TextBox_CheckingResult->Name = L"TextBox_CheckingResult";
		  this->TextBox_CheckingResult->Size = System::Drawing::Size(167, 37);
		  this->TextBox_CheckingResult->TabIndex = 7;
		  this->TextBox_CheckingResult->TextChanged += gcnew System::EventHandler(this, &laba1::textBox1_TextChanged_3);
		  // 
		  // button4
		  // 
		  this->button4->Location = System::Drawing::Point(506, 128);
		  this->button4->Name = L"button4";
		  this->button4->Size = System::Drawing::Size(125, 37);
		  this->button4->TabIndex = 8;
		  this->button4->Text = L"Checking sort";
		  this->button4->UseVisualStyleBackColor = true;
		  this->button4->Click += gcnew System::EventHandler(this, &laba1::button_CheckingSort);
		  // 
		  // laba1
		  // 
		  this->AutoScaleDimensions = System::Drawing::SizeF(9, 20);
		  this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
		  this->ClientSize = System::Drawing::Size(643, 465);
		  this->Controls->Add(this->button4);
		  this->Controls->Add(this->TextBox_CheckingResult);
		  this->Controls->Add(this->button3);
		  this->Controls->Add(this->textBox_SortingTime);
		  this->Controls->Add(this->button2);
		  this->Controls->Add(this->button_Exit);
		  this->Controls->Add(this->TextBox_Massive);
		  this->Controls->Add(this->TextBoxElement);
		  this->Controls->Add(this->button1);
		  this->Name = L"laba1";
		  this->Text = L"laba1";
		  this->ResumeLayout(false);
		  this->PerformLayout();

		}
		static array<double> ^arr;
		int indexLeftLimit, indexRightLimit;

#pragma endregion
	private:
	  void func_PrintArray()
	  {
		int arraySize = Convert::ToInt32(this->TextBoxElement->Text);
		TextBox_Massive->Clear();
		for (int i = 0; i < arraySize; i++)
		{
		  TextBox_Massive->AppendText(Convert::ToString(arr[i]) + " ");
		}
	  }
	  void func_Fill()
	  {
		int arraySize = Convert::ToInt32(this->TextBoxElement->Text);
		arr = gcnew array<double>(arraySize);
		Random ^randomizer = gcnew Random();

		for (int i = 0; i < arraySize; i++)
		{
		  arr[i] = randomizer->Next(-100, 100);
		}
	  }
	  void func_FindSortLimits()
	  {
		indexLeftLimit = arr->Length + 1;
		//шукаємо границі сортування
		for (int i = 0; i < arr->Length; i++)
		{
		  if (arr[i] < 0 && indexLeftLimit == arr->Length + 1)
		  {
			indexLeftLimit = i;
		  }
		  if (arr[i] < 0)
		  {
			indexRightLimit = i;
		  }
		}
	  }
	  void func_Sort()
	  {
		func_FindSortLimits();
		//сортуємо
		for (int i = indexLeftLimit; i < indexRightLimit + 1; i++)
		{
		  double minValue = arr[i];
		  int indexMinValue = i;
		  for (int j = i; j < indexRightLimit + 1; j++)
		  {
			if (minValue > arr[j])
			{
			  minValue = arr[j];
			  indexMinValue = j;
			}
		  }
		  arr[indexMinValue] = arr[i];
		  arr[i] = minValue;
		}
	  }
	  bool func_IsCheckingSort()
	  {
		for (int i = indexLeftLimit; i < indexRightLimit; i++)
		{
		  if (arr[i] > arr[i + 1])
		  {
			return false;
		  }
		}
		return true;
	  }
	private: System::Void button_CreateArray(System::Object ^sender, System::EventArgs ^e)
	{
	  func_Fill();
	}
	private: System::Void textBox1_TextChanged(System::Object ^sender, System::EventArgs ^e)
	{

	}
	private: System::Void textBox1_TextChanged_1(System::Object ^sender, System::EventArgs ^e)
	{

	}
private: System::Void funcButton_Exit(System::Object ^sender, System::EventArgs ^e)
{
  delete[] arr;
  Environment::Exit(0);
}
private: System::Void button_SortArray(System::Object ^sender, System::EventArgs ^e)
{
  Stopwatch ^stopWatch = gcnew Stopwatch();
  stopWatch->Start();
  func_Sort();
  stopWatch->Stop();
  // потрачений час у мілісекундах
  long long elapsedMilliseconds = stopWatch->ElapsedMilliseconds;

  textBox_SortingTime->Text = "Time: " + Convert::ToString(elapsedMilliseconds) + " ms";
}
private: System::Void func_textBox_SortingTime(System::Object ^sender, System::EventArgs ^e)
{

}
private: System::Void button_PrintArray(System::Object ^sender, System::EventArgs ^e)
{
  func_PrintArray();
}
private: System::Void textBox1_TextChanged_3(System::Object ^sender, System::EventArgs ^e)
{

}
private: System::Void button_CheckingSort(System::Object ^sender, System::EventArgs ^e)
{
  if (func_IsCheckingSort())
  {
	TextBox_CheckingResult->Text = "True";
  }
  else
  {
	TextBox_CheckingResult->Text = "False";
  }
}
};
}
