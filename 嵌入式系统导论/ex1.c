#include "stm32f10x.h"
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
	GPIO_Init(GPIOC, &GPIO_InitStructure);
}
unsigned int Key0_Read(){
	if(!GPIO_ReadInputDataBit(GPIOC, GPIO_Pin_5))
		return 1;
	else
		return 0;
}
int main(){
	unsigned int key_no=0;
	LED0_Config();
	KEY0_Config();
	LED0_Off();
	while(1)
	{
		key_no=Key0_Read();
		if(key_no)
			LED0_On();
		else
			LED0_Off();
	}
}
