// Fill out your copyright notice in the Description page of Project Settings.


#include "DabuController.h"

// Sets default values
ADabuController::ADabuController()
{
	// Set this pawn to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	bShowMouseCursor = true; // 마우스 커서 활성화
	DefaultMouseCursor = EMouseCursor::Default; // 마우스 커서 모양 디폴트
	
}

// Called when the game starts or when spawned
void ADabuController::BeginPlay()
{
	Super::BeginPlay();
	
}