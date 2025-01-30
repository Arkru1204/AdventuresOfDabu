// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/PlayerController.h"
#include "DabuController.generated.h"

/**
 * 
 */
UCLASS()
class ADVENTURESOFDABU_API ADabuController : public APlayerController
{
	GENERATED_BODY()

public:
	// Sets default values for this pawn's properties
	ADabuController();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

};
