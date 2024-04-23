#include "stm32f10x.h"
void delay(int n){
	int i;
	for (i = 0; i < n; i++);
}
void LED0_Config(){
	GPIO_InitTypeDef GPIO_InitStructure;
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOD, ENABLE);
	GPIO_InitStructure.GPIO_Pin=GPIO_Pin_2;
	GPIO_InitStructure.GPIO_Mode=GPIO_Mode_Out_PP;
	GPIO_InitStructure.GPIO_Speed=GPIO_Speed_2MHz;
	GPIO_Init(GPIOD, &GPIO_InitStructure);
}
void LED0_On(){
	GPIO_ResetBits(GPIOD, GPIO_Pin_2);
}
void LED0_Off(){
	GPIO_SetBits(GPIOD, GPIO_Pin_2);
}
int main (void){
	LED0_Config();
	while(1)
	{
		int i;
    for (i = 0; i < 2500; i++) {
			LED0_Off();
			delay(i+500);
			LED0_On();
			delay(2500 - i-500);
		}
		for (i = 0; i < 2500; i++) {
			LED0_Off();
			delay(2500 - i-500);
			LED0_On();
			delay(i+500);
		}
	}
}
