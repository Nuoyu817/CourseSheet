#include "stm32f10x.h"
void TIM1_PWMInit(){
	GPIO_InitTypeDef GPIO_InitStructure;
	TIM_TimeBaseInitTypeDef TIM_TimeBaseStructure;
	TIM_OCInitTypeDef TimOCInitStructure;
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA, ENABLE) ;
	GPIO_InitStructure.GPIO_Pin=GPIO_Pin_8;
	GPIO_InitStructure.GPIO_Mode=GPIO_Mode_AF_PP;
	GPIO_InitStructure.GPIO_Speed=GPIO_Speed_50MHz;
	GPIO_Init(GPIOA, &GPIO_InitStructure);
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_TIM1, ENABLE);
	TIM_TimeBaseStructure.TIM_Prescaler= 72-1;
	TIM_TimeBaseStructure.TIM_Period= 50-1;
	TIM_TimeBaseStructure.TIM_CounterMode=TIM_CounterMode_Up;
	TIM_TimeBaseInit(TIM1, &TIM_TimeBaseStructure);
	TimOCInitStructure.TIM_OCMode=TIM_OCMode_PWM1;
	TimOCInitStructure.TIM_OCPolarity=TIM_OCPolarity_High;
	TimOCInitStructure.TIM_Pulse= 47;
	TimOCInitStructure.TIM_OutputState=TIM_OutputState_Enable;
	TIM_OC1Init(TIM1, &TimOCInitStructure);
	TIM_OC1PreloadConfig(TIM1, TIM_OCPreload_Enable);
	TIM_ARRPreloadConfig(TIM1, ENABLE);
	TIM_Cmd(TIM1, ENABLE);
	TIM_CtrlPWMOutputs(TIM1, ENABLE);
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
int main(void){
	TIM1_PWMInit();
	LED1_Config();
	while(1)
	{
		LED1_On();
	}
}
