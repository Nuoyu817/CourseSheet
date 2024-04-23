#include "stm32f10x.h"
#include <stdio.h>
#define ITM_Port8(n) (*((volatile unsigned char*)(0xE0000000+4*n)))
#define ITM_Port16(n) (*((volatile unsigned short*)(0xE0000000+4*n)))
#define ITM_Port32(n) (*((volatile unsigned long*)(0xE0000000+4*n)))
#define DEMCR (*((volatile unsigned long*)(0xE000EDFC)))
#define TRCENA 0x01000000
struct __FILE{
	int handle;
};
FILE __stdout;
FILE __stdin;
int fputc(int ch, FILE *f){
	if(DEMCR & TRCENA)
	{
		while(ITM_Port32(0)==0);
		ITM_Port8(0)=ch;
	}
	return(ch);
}
unsigned int CountOfToggle=0;
void LED0_Config(){
	GPIO_InitTypeDef GPIO_InitStructure;
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA, ENABLE);
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
void TIM2_Delay500MS(){
	TIM_TimeBaseInitTypeDef TIM_TimeBaseStructure;
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM2, ENABLE);
	TIM_TimeBaseStructure.TIM_Prescaler=36000-1;
	TIM_TimeBaseStructure.TIM_Period=6160-1;
	TIM_TimeBaseStructure.TIM_CounterMode=TIM_CounterMode_Up;
	TIM_TimeBaseInit(TIM2, &TIM_TimeBaseStructure);
	TIM_ClearFlag(TIM2, TIM_FLAG_Update);
	TIM_Cmd(TIM2, ENABLE);
	while(TIM_GetFlagStatus(TIM2, TIM_FLAG_Update)==RESET);
}
int main (void){
	LED0_Config();
	while(1)
	{
		LED0_On();
		TIM2_Delay500MS();
		LED0_Off();
		TIM2_Delay500MS();
		CountOfToggle++;
		printf("The Count of Toggle is %d\n", CountOfToggle);
	}
}

