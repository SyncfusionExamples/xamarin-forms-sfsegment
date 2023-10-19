# Xamarin Segmented Control (SfSegmentedControl) 

The Segmented Control for Xamarin.Forms provides a simple way to choose from a linear set of two or more segments, each of which functions as a mutually exclusive button.

For know more details about Segmented: https://www.syncfusion.com/xamarin-ui-controls/xamarin-segmented-control

Segmented user guide documentation: https://help.syncfusion.com/xamarin/segmented-control/getting-started

# Getting Started with Xamarin Segmented Control (SfSegmentedControl)

This section provides an overview for working with the segmented control for Xamarin.Forms. Walk through the entire process of creating a real-world application with the SfSegmentedControl.

# Adding SfSegmentedControl reference
You can add SfSegmentedControl reference using one of the following methods:

## Method 1: Adding SfSegmentedControl reference from nuget.org

Syncfusion Xamarin components are available in nuget.org. To add SfSegmentedControl to your project, open the NuGet package manager in Visual Studio, search for Syncfusion.Xamarin.Buttons, and then install it.

## Method 2: Adding SfSegmentedControl reference from toolbox

Syncfusion also provides Xamarin Toolbox. Using this toolbox, you can drag the SfSegmentedControl control to the XAML page. It will automatically install the required NuGet packages and add the namespace to the page. To install Syncfusion Xamarin Toolbox, refer to Toolbox.

## Method 3: Adding SfSegmentedControl assemblies manually from the installed location

If you prefer to manually reference the assemblies instead referencing from NuGet, add the following assemblies in respective projects.

Location: {Installed location}/{version}/Xamarin/lib

# Creating a project
Create a new BlankApp (Xamarin.Forms.Portable) application in Visual Studio for Xamarin.Forms.

## Adding SfSegmentedControl in Xamarin.Forms
Add the required assembly references to the PCL and renderer projects as discussed in the Assembly deployment  section.

Import the control namespace as shown in the following code.

**[XAML]**

```
xmlns:buttons="clr-namespace:Syncfusion.XForms.Buttons;assembly=Syncfusion.Buttons.XForms"
```
Set the control to content in ContentPage.

**[XAML]**
```
<ContentPage.Content>
    <buttons:SfSegmentedControl  />
</ContentPage.Content>
```
## Adding supportive views to the application
For the completeness of the ticket booking application, few framework controls are added to the application to get the data from the user.

ViewModel class for the Entry, which we have used in our View.

**[C#]**
```
    using Syncfusion.XForms.Buttons;
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Xamarin.Forms;
    
    namespace SegmentGettingStarted
    {
        class ViewModel : INotifyPropertyChanged
        {
            private string fromText="";
            public string FromText
            {
                get { return fromText; }
                set { fromText = value; NotifyPropertyChanged("FromText"); }
            }
            private string toText = "";
            public string ToText
            {
                get { return toText; }
                set { toText = value; NotifyPropertyChanged("ToText"); }
            }
            public ViewModel()
            {
            }
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
```
View can be created by the following code snippet.

**[XAML]**

```
    <ContentPage.BindingContext>
        <local:ViewModel/>
    </ContentPage.BindingContext>
    <StackLayout 
        HorizontalOptions="Center"
        VerticalOptions="Center"
        Padding="20,0,20,0">
        <Label
            Text="Bus Ticket Booking"
            FontSize="Large"
            FontAttributes="Bold"
            HeightRequest="50"
            HorizontalOptions="Center"
            VerticalOptions="Center"/>
        <Entry
            Placeholder="From"
            Text="{Binding FromText,Mode=TwoWay}"
            HeightRequest="50"
            Margin="0,10,0,10"/>
        <Entry
            Placeholder="To"
            Text="{Binding ToText}"
            HeightRequest="50"
            Margin="0,10,0,10"/>
        <buttons:SfSegmentedControl 
            x:Name="Class" 
            HeightRequest="80"
            VisibleSegmentsCount="2"
            Color="White"
            SelectionTextColor="#007CEE"
            FontColor="#929292"
            BorderColor="#929292"
            SelectedIndex="1"
            ItemsSource="{Binding ItemCollection,Mode=TwoWay}"
            BackgroundColor="Transparent">
            <buttons:SfSegmentedControl.SelectionIndicatorSettings>
                <buttons:SelectionIndicatorSettings 
                    Color="White">
                </buttons:SelectionIndicatorSettings>
            </buttons:SfSegmentedControl.SelectionIndicatorSettings>
        </buttons:SfSegmentedControl>
        <buttons:SfSegmentedControl
            SelectionTextColor="White"
            HeightRequest="80"
            VisibleSegmentsCount="6"
            Color="Transparent" 
            BorderColor="#929292"
            SelectedIndex="1"
            ItemsSource="{Binding}"
            FontColor="#929292"
            BackgroundColor="Transparent" >
            <segmentCollection:List x:TypeArguments="x:String">
                <x:String>1</x:String>
                <x:String>2</x:String>
                <x:String>3</x:String>
                <x:String>4</x:String>
                <x:String>5</x:String>
                <x:String>6</x:String>
            </segmentCollection:List>
            <buttons:SfSegmentedControl.SelectionIndicatorSettings>
                <buttons:SelectionIndicatorSettings 
                    Color="#007CEE"
                    Position="Fill">
                </buttons:SelectionIndicatorSettings>
            </buttons:SfSegmentedControl.SelectionIndicatorSettings>
        </buttons:SfSegmentedControl>
        <buttons:SfSegmentedControl
            BorderColor="Transparent" 
            HeightRequest="80"
            HorizontalOptions="Center"
            x:Name="ViewContainer"
            VisibleSegmentsCount="2"
            Color="Transparent"
            ItemsSource="{Binding ViewCollection}"
            SegmentPadding="30">
            <buttons:SfSegmentedControl.SelectionIndicatorSettings>
                <buttons:SelectionIndicatorSettings
                    Color="Transparent">
                </buttons:SelectionIndicatorSettings>
            </buttons:SfSegmentedControl.SelectionIndicatorSettings>
        </buttons:SfSegmentedControl>
    </StackLayout>
```

