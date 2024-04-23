#include "stm32f10x.h"
void delay(long n){
	long i;
	for (i = 0; i < n; i++);
}
void LED0_Config(){
	GPIO_InitTypeDef GPIO_InitStructure;
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA,ENABLE);
	GPIO_InitStructure.GPIO_Pin=GPIO_Pin_8;
	GPIO_InitStructure.GPIO_Mode=GPIO_Mode_Out_PP;
	GPIO_InitStructure.GPIO_Speed=GPIO_Speed_2MHz;
	GPIO_Init(GPIOA, &GPIO_InitStructure);
}
void LED0_On(){
	GPIO_ResetBits(GPIOA, GPIO_Pin_8);
}
void LED0_Off(){
	GPIO_SetBits(GPIOA, GPIO_Pin_8);
}
void KEY0_Config(){
	GPIO_InitTypeDef GPIO_InitStructure;
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOC, ENABLE);
	GPIO_InitStructure.GPIO_Mode=GPIO_Mode_IPU;
	GPIO_InitStructure.GPIO_Pin=GPIO_Pin_5;
	GPIO_InitStructure.GPIO_Speed=GPIO_Speed_2MHz;
	GPIO_Init(GPIOC, &GPIO_InitStructure);
}
unsigned int Key0_Read(){
	if(!GPIO_ReadInputDataBit(GPIOC, GPIO_Pin_5))
		return 1;
	else
		return 0;
}
void KEY1_Config(){
	GPIO_InitTypeDef GPIO_InitStructure;
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA, ENABLE);
	GPIO_InitStructure.GPIO_Mode=GPIO_Mode_IPU;
	GPIO_InitStructure.GPIO_Pin=GPIO_Pin_15;
	GPIO_InitStructure.GPIO_Speed=GPIO_Speed_2MHz;
	GPIO_Init(GPIOA, &GPIO_InitStructure);
}
unsigned int Key1_Read(){
	if(!GPIO_ReadInputDataBit(GPIOA, GPIO_Pin_15))
		return 1;
	else
		return 0;
}
void LED1_Config(){
	GPIO_InitTypeDef GPIO_InitStructure;
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOD,ENABLE);
	GPIO_InitStructure.GPIO_Pin=GPIO_Pin_2;
	GPIO_InitStructure.GPIO_Mode=GPIO_Mode_Out_PP;
	GPIO_InitStructure.GPIO_Speed=GPIO_Speed_2MHz;
	GPIO_Init(GPIOD, &GPIO_InitStructure);
}
void LED1_On(){
	GPIO_ResetBits(GPIOD, GPIO_Pin_2);
}
void LED1_Off(){
	GPIO_SetBits(GPIOD, GPIO_Pin_2);
}
int main(){
	unsigned int key0, key1;
	long i=0;
	LED0_Config();
	LED1_Config();
	KEY0_Config();
	KEY1_Config();
	LED0_Off();
	LED1_Off();
	key0=Key0_Read();
	i=0;
	while(1)
	{
		if(Key0_Read()==1) 
		{
			LED1_Off();
			for(i; i<3000; i++) 
			{
				LED0_On();
				delay(i);
				LED0_Off();
				delay(3000 - i);
				key0=Key0_Read();
				if(Key0_Read()==0)
					break;
			}
			while(1)
			{
				LED0_On();
				delay(i);
				LED0_Off();
				delay(3000 - i);
				if(Key0_Read()==0)
					break;
			}
			while(Key0_Read()==0)
			{
				LED0_On();
				delay(i);
				LED0_Off();
				delay(3000 - i);
				if(Key1_Read()==1) 
					break;
			}
		}
		
		if(Key1_Read()==1) 
		{
			
			for(i; i>=0; i--) 
			{
				
				LED0_On();
				delay(i);
				LED0_Off();
				delay(3000 - i);
				key1=Key1_Read();
				if(Key1_Read()==0)
					break;
			}
			while(1)
			{
				LED0_On();
				delay(i);
				LED0_Off();
				delay(3000 - i);
				if(Key1_Read()==0)
					break;
			}
			while(Key1_Read()==0)
			{
				LED0_On();
				delay(i);
				LED0_Off();
				delay(3000 - i);
				if(Key0_Read()==1) 
					break;
			}
		}
	}
}

