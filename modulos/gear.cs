using System; 

using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace DocEntry
{
	class Gear
	{
	
		///***************************************************************************/
		///*                                                                         */
		///* MODULE:  Gear.bas - Master AccuSoft ImageGear include file              */
		///*                                                                         */
		///*                                                                         */
		///* DATE CREATED:  01/30/1996                                               */
		///*                                                                         */
		///* $Date:: 12/23/96 9:10a $                                                */
		///* $Revision:: 345  $                                                      */
		///*                                                                         */
		///* Copyright (c) 1996, AccuSoft Corporation.  All rights reserved.         */
		///*                                                                         */
		///***************************************************************************/
		
		///***************************************************************************/
		///* ImageGear preprocessor macros                                           */
		///***************************************************************************/
		
		public const int SB_HORZ = 0;
		public const int SB_VERT = 1;
		
		///*
		// * Scroll Bar Commands
		// */
		public const int SB_LINEUP = 0;
		public const int SB_LINELEFT = 0;
		public const int SB_LINEDOWN = 1;
		public const int SB_LINERIGHT = 1;
		public const int SB_PAGEUP = 2;
		public const int SB_PAGELEFT = 2;
		public const int SB_PAGEDOWN = 3;
		public const int SB_PAGERIGHT = 3;
		public const int SB_THUMBPOSITION = 4;
		public const int SB_THUMBTRACK = 5;
		public const int SB_TOP = 6;
		public const int SB_LEFT = 6;
		public const int SB_BOTTOM = 7;
		public const int SB_RIGHT = 7;
		public const int SB_ENDSCROLL = 8;
		
		///* raster post processing constants */
		public const int POST_PROCESS_ABIC_GREY_LUT = 1;
		public const int POST_PROCESS_INVERT_BITONAL_RASTER = 2;
		
		
		///* Alpha Channel Constants */
		public const int IG_ALPHA_CREATE_1 = 0;
		public const int IG_ALPHA_CREATE_8 = 1;
		
		public const int IG_BLEND_OVER = 0;
		public const int IG_BLEND_IN = 1;
		public const int IG_BLEND_HELD_OUT = 2;
		public const int IG_BLEND_LINEAR = 3;
		
		///* scan capabilities constants */
		public const int IG_SCAN_CAP_PIXELTYPE = 0;
		public const int IG_SCAN_CAP_XREFCOUNT = 1;
		public const int IG_SCAN_CAP_XFERCOUNT = 1;
		public const int IG_SCAN_CAP_PIXELFLAVOR = 2;
		
		public const int IG_SCAN_CAP_CONTRAST = 3;
		public const int IG_SCAN_CAP_BRIGHTNESS = 4;
		public const int IG_SCAN_CAP_XRES = 5;
		public const int IG_SCAN_CAP_YRES = 6;
		public const int IG_SCAN_CAP_BITSPERPIX = 7;
		
		public const int IG_SCAN_CAP_LAYOUT_LEFT = 8;
		public const int IG_SCAN_CAP_LAYOUT_RIGHT = 9;
		public const int IG_SCAN_CAP_LAYOUT_TOP = 10;
		public const int IG_SCAN_CAP_LAYOUT_BOTTOM = 11;
		
		// some pseudo-caps
		public const int IG_SCAN_CONTROL_PAPER_SOURCE = 12; //  see constants below IG_SCAN_PAPER_
		public const int IG_SCAN_CONTROL_FILE_APPEND = 13; //  BOOL, default FALSE
		public const int IG_SCAN_CONTROL_DISABLE_DISPLAY = 14; //  BOOL, default FALSE
		public const int IG_SCAN_CONTROL_SAVE_PAGES_SEPARATELY = 15; //  BOOL, default FALSE
		
		public const int IG_SCAN_CONTROL_SCAN_PAGES_MODELESS = 16; //  BOOL, default FALSE
		
		public const int IG_SCAN_CONTROL_APP_NAME = 17; //  Name of application
		
		public const int IG_PIXEL_TYPE_BW = 0;
		public const int IG_PIXEL_TYPE_GRAY = 1;
		public const int IG_PIXEL_TYPE_RGB = 2;
		public const int IG_PIXEL_TYPE_PALETTE = 3;
		
		public const int IG_SCAN_PF_CHOCOLATE = 0;
		public const int IG_SCAN_PF_VANILLA = 1;
		
		public const int IG_SCAN_PAPER_AUTO = 0; //  default
		public const int IG_SCAN_PAPER_FLATBED = 1;
		public const int IG_SCAN_PAPER_ADF = 2;
		
		
		///* bitmapped color components                                              */
		public const int IG_COLOR_COMP_R = 1;
		public const int IG_COLOR_COMP_G = 2;
		public const int IG_COLOR_COMP_B = 4;
		public static readonly int IG_COLOR_COMP_RGB = (IG_COLOR_COMP_R | IG_COLOR_COMP_G | IG_COLOR_COMP_B);
		public const int IG_COLOR_COMP_I = 16; // /* used when the ave of RGB is to be used*/
		
		
		///* values for nAspectMethod parameter of IG_display_adjust_aspect          */
		public const int IG_ASPECT_NONE = 0;
		public const int IG_ASPECT_DEFAULT = 1;
		public const int IG_ASPECT_HORIZONTAL = 2;
		public const int IG_ASPECT_VERTICAL = 3;
		public const int IG_ASPECT_MAXDIMENSION = 4;
		public const int IG_ASPECT_MINDIMENSION = 1;
		
		
		///* values for altering the contrast of an image                            */
		public const int IG_CONTRAST_PALETTE = 0; // /* Alter the palette only        */
		public const int IG_CONTRAST_PIXEL = 1; // /* Alter the pixel values        */
		
		
		///* values for nFitMethod parameter of IG_display_fit_method                */
		public const int IG_DISPLAY_FIT_TO_WINDOW = 0;
		public const int IG_DISPLAY_FIT_TO_WIDTH = 1;
		public const int IG_DISPLAY_FIT_TO_HEIGHT = 2;
		public const int IG_DISPLAY_FIT_1_TO_1 = 3;
		
		
		///* values for nPriority parameter of IG_display_handle_palette             */
		public const int IG_PALETTE_PRIORITY_DEFAULT = 0;
		public const int IG_PALETTE_PRIORITY_HIGH = 1;
		public const int IG_PALETTE_PRIORITY_LOW = 2;
		public const int IG_PALETTE_PRIORITY_DISABLE = 3;
		public const int IG_PALETTE_PRIORITY_NOREALIZE = 4; // /* Same as IG_PALETTE_PRIORITY_DISABLE, */
		
		///* values for nDitherMode parameter of IG_display_dither_mode_set          */
		public const int IG_DITHER_MODE_DEFAULT = 0;
		public const int IG_DITHER_MODE_NONE = 1;
		public const int IG_DITHER_MODE_BAYER = 2;
		
		
		///* values for direction parameter of IG_IP_flip function                   */
		public const int IG_FLIP_HORIZONTAL = 0;
		public const int IG_FLIP_VERTICAL = 1;
		public const int IG_SHEAR_HORIZONTAL = 0;
		public const int IG_SHEAR_VERTICAL = 1;
		
		public const int IG_LOADDOC_DISPLAY_FIRST = 0;
		public const int IG_LOADDOC_DISPLAY_ALL = 1;
		
		///* values for IG_IP_rotate_ function                                       */
		public const int IG_ROTATE_CLIP = 0;
		public const int IG_ROTATE_EXPAND = 1;
		
		public const int IG_ROTATE_0 = 0;
		public const int IG_ROTATE_90 = 1;
		public const int IG_ROTATE_180 = 2;
		public const int IG_ROTATE_270 = 3;
		
		
		///* values for PROMOTE function                                             */
		public const int IG_PROMOTE_TO_4 = 1;
		public const int IG_PROMOTE_TO_8 = 2;
		public const int IG_PROMOTE_TO_24 = 3;
		
		
		///* General purpose compass directions                                      */
		public const int IG_COMPASS_N = 1;
		public const int IG_COMPASS_NE = 2;
		public const int IG_COMPASS_E = 3;
		public const int IG_COMPASS_SE = 4;
		public const int IG_COMPASS_S = 5;
		public const int IG_COMPASS_SW = 6;
		public const int IG_COMPASS_W = 7;
		public const int IG_COMPASS_NW = 8;
		
		
		
		
		///* IG_load_color()                                                         */
		public const int IG_LOAD_COLOR_DEFAULT = 0;
		public const int IG_LOAD_COLOR_1 = 1;
		public const int IG_LOAD_COLOR_4 = 2;
		public const int IG_LOAD_COLOR_8 = 3;
		public const int IG_LOAD_GRAYSCALE_8 = 4;
		
		///* IG_palette_save()                                                       */
		public const int IG_PALETTE_FORMAT_INVALID = 0; // /* returned when file could not be read   */
		public const int IG_PALETTE_FORMAT_RAW_BGR = 1; // /* This is the raw DIB format BGR         */
		public const int IG_PALETTE_FORMAT_RAW_BGRQ = 2; // /* This is the raw DIB format BGRQ        */
		public const int IG_PALETTE_FORMAT_RAW_RGB = 3; // /* This is the raw DIB format RGB         */
		public const int IG_PALETTE_FORMAT_RAW_RGBQ = 4; // /* This is the raw DIB format RGBQ        */
		public const int IG_PALETTE_FORMAT_TEXT = 5; // /* ASCII text file (details in manual)    */
		public const int IG_PALETTE_FORMAT_HALO_CUT = 6; // /* Dr Halo .PAL file for use with a .CUT  */
		
		
		///* IG_FX_twist()  type parameter                                           */
		public const int IG_TWIST_90 = 1;
		public const int IG_TWIST_180 = 2;
		public const int IG_TWIST_270 = 3;
		public const int IG_TWIST_RANDOM = 4;
		
		
		///* values for nAliasType parameter of IG_display_alias_set()               */
		public const int IG_DISPLAY_ALIAS_NONE = 0;
		public const int IG_DISPLAY_ALIAS_PRESERVE_BLACK = 1;
		public const int IG_DISPLAY_ALIAS_SCALE_TO_GRAY = 2;
		public const int IG_DISPLAY_ALIAS_PRESERVE_BLACK_SUB = 3;
		public const int IG_DISPLAY_ALIAS_SCALE_TO_GRAY_SUB = 4;
		
		///* values for nOption parameter of IG_display_option_set()                 */
		public const int IG_DISPLAY_OPTION_DOWNSHIFT = 1;
		public const int IG_DISPLAY_OPTION_LUT = 2;
		public const int IG_ORIENTATION_SUPPORT = 3;
		public const int IG_PRINT_ADJUST = 4;
		public const int IG_DISPLAY_OPTION_USEMAPMODE = 5;
		public const int IG_DISPLAY_OPTION_DDB_OPTIMIZE = 6;
		
		///* types of edge maps                                                      */
		public const int IG_EDGE_OP_PREWITT = 1;
		public const int IG_EDGE_OP_ROBERTS = 2;
		public const int IG_EDGE_OP_SOBEL = 3;
		public const int IG_EDGE_OP_LAPLACIAN = 4;
		public const int IG_EDGE_OP_HORIZONTAL = 5;
		public const int IG_EDGE_OP_VERTICAL = 6;
		public const int IG_EDGE_OP_DIAG_POS_45 = 7;
		public const int IG_EDGE_OP_DIAG_NEG_45 = 8;
		
		
		///* Types of structuring Elements and Convolution kernels                   */
		public const int IG_MAX_KERN_HEIGHT = 16;
		public const int IG_MAX_KERN_WIDTH = 16;
		
		
		///* Types of convolution data output formats                                */
		public const int IG_CONV_RESULT_RAW = 0;
		public const int IG_CONV_RESULT_ABS = 1;
		public const int IG_CONV_RESULT_8BIT_SIGNED = 2;
		public const int IG_CONV_RESULT_SIGN_CENTERED = 3;
		
		
		///* Types of 24 bit convolution data inputs                                 */
		public const int IG_CONV_24_INTENSITY = 0;
		public const int IG_CONV_24_RGB = 1;
		public const int IG_CONV_24_R = 2;
		public const int IG_CONV_24_G = 3;
		public const int IG_CONV_24_B = 4;
		
		
		///* values for nFillOrder parameter of IG_load_CCITT_FD()                   */
		public const int IG_FILL_MSB = 1;
		public const int IG_FILL_LSB = 2;
		
		
		///* IG_IP_arithmetic                                                        */
		public const int IG_ARITH_ADD = 1; // /* Add   Img1 = Img1 + Img2         */
		public const int IG_ARITH_SUB = 2; // /* Sub   Img1 = Img1 - Img2         */
		public const int IG_ARITH_MULTI = 3; // /* Multi Img1 = Img1 * Img2         */
		public const int IG_ARITH_DIVIDE = 4; // /* Div   Img1 = Img1 / Img2         */
		public const int IG_ARITH_AND = 5; // /* AND   Img1 = Img1 & Img2         */
		public const int IG_ARITH_OR = 6; // /* OR    Img1 = Img1  Or  Img2         */
		public const int IG_ARITH_XOR = 7; // /* XOR   Img1 = Img1 ^ Img2         */
		public const int IG_ARITH_ADD_SIGN_CENTERED = 8; // /* NOT   Img1 = Img1 + SC_Img2      */
		public const int IG_ARITH_NOT = 9; // /* NOT   Img1 = ~Img1               */
		public const int IG_ARITH_OVER = 10; // /* NOT   Img1 = Img2                  */
		
		///* Types of image blending modes                               */
		public const int IG_BLEND_ON_INTENSITY = 0;
		public const int IG_BLEND_ON_IMAGE = 1;
		public const int IG_BLEND_ON_HUE = 2;
		
		
		///* Encryption mode                                                         */
		public const int IG_ENCRYPT_METHOD_A = 0; // /* Method A                         */
		public const int IG_ENCRYPT_METHOD_B = 1; // /* Method B                         */
		public const int IG_ENCRYPT_METHOD_C = 2; // /* Method C                         */
		
		
		///* Color spaces                                                            */
		public const int IG_COLOR_SPACE_RGB = 0; // /* RGB                              */
		public const int IG_COLOR_SPACE_I = 1; // /* Intensity                        */
		public const int IG_COLOR_SPACE_IHS = 2; // /* IHS                              */
		public const int IG_COLOR_SPACE_HSL = 3; // /* HSL                              */
		public const int IG_COLOR_SPACE_Lab = 4; // /* Lab                              */
		public const int IG_COLOR_SPACE_YIQ = 5; // /* YIQ                              */
		public const int IG_COLOR_SPACE_CMY = 6; // /* CMY                              */
		public const int IG_COLOR_SPACE_CMYK = 7; // /* CMYK                             */
		public const int IG_COLOR_SPACE_YCrCb = 8; // /* YCrCb                            */
		public const int IG_COLOR_SPACE_YUV = 9; // /* YUV                              */
		
		///* the following constants are used with the FlashPix */
		public const int IG_COLOR_SPACE_MONO = 10; // /* 8bit grayscale                                                 */
		public const int IG_COLOR_SPACE_ALPHA = 11; // /* 8bit alpha                                                             */
		public const int IG_COLOR_SPACE_MA = 12; // /* 16bit: mono + alpha                                    */
		public const int IG_COLOR_SPACE_AM = 13; // /* 16bit: alpha + mono                                    */
		public const int IG_COLOR_SPACE_RGBA = 14; // /* 32bit: RGB + alpha                                     */
		public const int IG_COLOR_SPACE_ARGB = 15; // /* 32bit: alpha + RGB                                     */
		public const int IG_COLOR_SPACE_YCC = 16; // /* 24bit: PhotoYCC                                                */
		public const int IG_COLOR_SPACE_YCCA = 17; // /* 32bit: PhotoYCC + alpha                                */
		public const int IG_COLOR_SPACE_AYCC = 18; // /* 32bit: alpha + PhotoYCC                                */
		public const int IG_COLOR_SPACE_UNKNOWN = 19; // /* unknown or invalid colorspace          */
		public const int IG_COLOR_SPACE_NOCHANGE = 20; // /* use current colorspace                         */
		
		
		///* IG_FX_pixelate                                                          */
		public const int IG_PIXELATE_CENTER = 0; // /* Sample center of each block      */
		public const int IG_PIXELATE_AVERAGE = 1; // /* Compute the average of each block*/
		
		///* nWipeStyle of IG_display_image_wipe()                                                                                               */
		public const int IG_WIPE_LEFTTORIGHT = 0;
		public const int IG_WIPE_RIGHTTOLEFT = 1;
		public const int IG_WIPE_UP_TO_DOWN = 22;
		public const int IG_WIPE_DOWN_TO_UP = 23;
		public const int IG_WIPE_SPARKLE = 2;
		public const int IG_WIPE_ULTOLRDIAG = 3;
		public const int IG_WIPE_LRTOULDIAG = 24;
		public const int IG_WIPE_URTOLLDIAG = 25;
		public const int IG_WIPE_LLTOURDIAG = 26;
		public const int IG_WIPE_CLOCK = 4;
		public const int IG_WIPE_SPARKLE_CLOCK = 5;
		public const int IG_WIPE_DOUBLE_CLOCK = 6;
		public const int IG_WIPE_SLIDE_RIGHT = 7;
		public const int IG_WIPE_SLIDE_LEFT = 8;
		public const int IG_WIPE_SLIDE_UP = 27;
		public const int IG_WIPE_SLIDE_DOWN = 28;
		public const int IG_WIPE_RANDOM_BARS_DOWN = 9;
		public const int IG_WIPE_RAIN = 10;
		public const int IG_WIPE_BOOK = 11;
		public const int IG_WIPE_ROLL = 12;
		public const int IG_WIPE_UNROLL = 13;
		public const int IG_WIPE_EXPAND_PROPORTIONAL = 14;
		public const int IG_WIPE_EXPAND_HORIZONTAL = 15;
		public const int IG_WIPE_EXPAND_VERTICAL = 16;
		public const int IG_WIPE_STRIPS_HORIZONTAL = 17;
		public const int IG_WIPE_STRIPS_VERTICAL = 18;
		public const int IG_WIPE_CELLS = 19;
		public const int IG_WIPE_BALL = 20;
		public const int IG_WIPE_GEARS = 21;
		
		
		///* Data types for use with tag callbacks                                                                                       */
		public const int IG_TAG_TYPE_NULL = 0; // /* no data -- end of tags                           */
		public const int IG_TAG_TYPE_BYTE = 1; // /* data is a 8 bit unsigned int                     */
		public const int IG_TAG_TYPE_ASCII = 2; // /* data is a 8 bit, NULL-term String                */
		public const int IG_TAG_TYPE_SHORT = 3; // /* data is a 16 bit,unsigned int                    */
		public const int IG_TAG_TYPE_LONG = 4; // /* data is a 32 bit, unsigned int                   */
		public const int IG_TAG_TYPE_RATIONAL = 5; // /* data is a two 32-bit unsigned integers           */
		public const int IG_TAG_TYPE_SBYTE = 6; // /* data is a 8 bit signed int                       */
		public const int IG_TAG_TYPE_UNDEFINED = 7; // /* data is a 8 bit byte                             */
		public const int IG_TAG_TYPE_SSHORT = 8; // /* data is a 16-bit signed int                      */
		public const int IG_TAG_TYPE_SLONG = 9; // /* data is a 32-bit signed int                      */
		public const int IG_TAG_TYPE_SRATIONAL = 10; // /* data is a two 32-bit signed int                  */
		public const int IG_TAG_TYPE_FLOAT = 11; // /* data is a 4-byte single-prec IEEE floating point */
		public const int IG_TAG_TYPE_DOUBLE = 12; // /* data is a 8-byte double-prec IEEE floating point */
		public const int IG_TAG_TYPE_RAWBYTES = 13; // /* data is a series of raw data bytes               */
		public const int IG_TAG_TYPE_LONGARRAY = 14; // /* data is an array of 32-bit signed ints           */
		public const int IG_TAG_TYPE_UNICODE = 15; // /* data is a UNICODE string, 16 bit WCHARs term. by two NULLs */
		public const int IG_TAG_TYPE_FILETIME = 16; // /* data is a 64 bit FILETIME structure                                     */
		public const int IG_TAG_TYPE_DATE = 17; // /* data is a 64 bit DATE structure                                               */
		
		///* FX Blur constants                                                                                                           */
		public const int IG_BLUR_3 = 1; // /* Blurs using a 3x3 kernel*/
		public const int IG_BLUR_5 = 2; // /* Blurs using a 5x5 kernel*/
		
		
		///* FX resample constants                                                                                                                       */
		public const int IG_RESAMPLE_IN_AVE = 0;
		public const int IG_RESAMPLE_IN_MIN = 1;
		public const int IG_RESAMPLE_IN_MAX = 2;
		public const int IG_RESAMPLE_IN_CENTER = 3;
		public const int IG_RESAMPLE_OUT_SQUARE = 0;
		public const int IG_RESAMPLE_OUT_CIRCLE = 1;
		
		
		///* FX noise constants                                                                                                                                  */
		public const int IG_NOISE_LINEAR = 0;
		public const int IG_NOISE_GAUSSIAN = 1;
		
		
		///* Multi Page Append image flag                                                                                                        */
		public const int IG_APPEND_PAGE = 0;
		
		
		///* Draw Contrast Ramp Constants                                                                                                                */
		public const int IG_RAMP_HORIZONTAL = 0;
		public const int IG_RAMP_VERTICAL = 1;
		public const int IG_RAMP_PYRAMID = 2;
		public const int IG_RAMP_FORWARD = 0;
		public const int IG_RAMP_REVERSE = 1;
		
		
		///* nPrintSize parameter of IG_print_page()                                                                             */
		public const int IG_PRINT_FULL_PAGE = 0;
		public const int IG_PRINT_THREE_QUARTER_PAGE = 1;
		public const int IG_PRINT_HALF_PAGE = 2;
		public const int IG_PRINT_QUARTER_PAGE = 3;
		public const int IG_PRINT_EIGHTH_PAGE = 4;
		public const int IG_PRINT_SIXTEENTH_PAGE = 5;
		public const int IG_PRINT_CUSTOM = 6;
		
		///* nHorzPos and nVertPos parameters of IG_print_page()                                                 */
		public const int IG_PRINT_ALIGN_LEFT = 0;
		public const int IG_PRINT_ALIGN_TOP = 0;
		public const int IG_PRINT_ALIGN_CENTER = 1;
		public const int IG_PRINT_ALIGN_RIGHT = 2;
		public const int IG_PRINT_ALIGN_BOTTOM = 2;
		
		
		///* nAttributeID parameter of IG_GUI_window_attribute_set()                                     */
		public const int IG_GUI_WINDOW_PAINT = 0;
		public const int IG_GUI_WINDOW_HANDLE_RESIZE = 1;
		public const int IG_GUI_WINDOW_IMAGE_ADD = 2;
		public const int IG_GUI_WINDOW_IMAGE_REMOVE = 3;
		public const int IG_GUI_WINDOW_ZOOM_KEYS = 4;
		public const int IG_GUI_WINDOW_ART_DISABLE = 5;
		
		///* Pixel Access data format                                                                                                                                    */
		public const int IG_PIXEL_PACKED = 1;
		public const int IG_PIXEL_UNPACKED = 2;
		public const int IG_PIXEL_RLE = 3;
		
		public const int IG_GUI_MAGNIFY_POPUP_WIDTH = 0;
		public const int IG_GUI_MAGNIFY_POPUP_HEIGHT = 1;
		public const int IG_GUI_MAGNIFY_POPUP_ZOOM = 2;
		public const int IG_GUI_MAGNIFY_POPUP_CIRCLE = 3;
		
		
		///* IG_DIB_area_get/set                                                  */
		public const int IG_DIB_AREA_RAW = 0; // /* all pixels as they are found     */
		public const int IG_DIB_AREA_DIB = 1; // /* pads rows to long boundries      */
		public const int IG_DIB_AREA_UNPACKED = 2; // /* 1 pixel per byte or 3 bytes (24) */
		
		
		///* ImageGear extension constants                                                                                                               */
		public const int IG_EXTENTION_LZW = 0;
		public const int IG_EXTENTION_MEDICAL = 1;
		public const int IG_EXTENTION_ABIC = 2;
		public const int IG_EXTENSION_FLASHPIX = 3;
		
		
		///* Area access functions                                                                                                                               */
		public const int IG_DIB_AREA_INFO_MIN = 1;
		public const int IG_DIB_AREA_INFO_MAX = 2;
		public const int IG_DIB_AREA_INFO_AVE = 3;
		public const int IG_DIB_AREA_INFO_CENTER = 4;
		
		
		///* Draw frame functions                                                                                                                                        */
		public const int IG_DRAW_FRAME_EXPAND = 1;
		public const int IG_DRAW_FRAME_OVERWRITE = 2;
		
		
		///* Image Resolution Units                                                                                                                              */
		public const int IG_RESOLUTION_NO_ABS = 1; // /* No Absolute Units                           */
		public const int IG_RESOLUTION_METERS = 2; // /* Pels (Pixels) Per Meter             */
		public const int IG_RESOLUTION_INCHES = 3; // /* Dots (Pixels) Per Inch              */
		public const int IG_RESOLUTION_CENTIMETERS = 4; // /* Pixles Per CentiMeter               */
		public const int IG_RESOLUTION_10_INCHES = 5; // /* Dots (Pixels) Per 10 Inch   */
		public const int IG_RESOLUTION_10_CENTIMETERS = 6; // /* Pixles Per 10 CentiMeter    */
		
		
		///* Interpolation methods                                                                                                                               */
		public const int IG_INTERPOLATION_NONE = 0;
		public const int IG_INTERPOLATION_AVERAGE = 1;
		public const int IG_INTERPOLATION_BILINEAR = 2;
		public const int IG_INTERPOLATION_NEAREST_NEIGHBOR = 3;
		public const int IG_INTERPOLATION_PADDING = 4;
		public const int IG_INTERPOLATION_GRAYSCALE = 5; // /* this is for IG7 Pro Gold users only: 1 bit to 8g */
		
		
		public const int IG_ORIENT_SUPPORT_NONE = 0; // /* orientation is not supported */
		public const int IG_ORIENT_SUPPORT_1BIT_PROGOLD = 1; // /* only 1 bit rle compressed images is rotated before displaying */
		public const int IG_ORIENT_SUPPORT_FULL = 2; // /* 1 bit rle compressed images rotated before displaying but all other images rotated during loading */
		
		///* color space support level */
		public const int IG_CONVERT_TO_RGB = 1;
		
		///* Image Orientation Units                                                                                                                                                                     */
		///* There are 8 possible orientations.  This AT_MODE lables them according to where the */
		///* the first row (row 0) and first col (col 0) of the image data is to be displayed.   */
		///* Normal images are display with row 0 at the top and column 0 at the left.  This is  */
		///* labled IG_ORIENT_TOP_LEFT.  The other orientations are combinations of flips and            */
		///* rotates.  Portrait is usually IG_ORIENT_TOP_LEFT, and Landscape is either                           */
		///* IG_ORIENT_RIGHT_TOP or IG_ORIENT_LEFT_BOTTOM.                                                                                                       */
		public const int IG_ORIENT_TOP_LEFT = 1; // /* Row0=Top            Col0=Left       Normal (Portrait)       */
		public const int IG_ORIENT_TOP_RIGHT = 2; // /* Row0=Top            Col0=Right      Flip-H                          */
		public const int IG_ORIENT_BOTTOM_RIGHT = 3; // /* Row0=Bottom Col0=Right      Rotate 180                      */
		public const int IG_ORIENT_BOTTOM_LEFT = 4; // /* Row0=Bottom Col0=Left       Flip-V                          */
		public const int IG_ORIENT_LEFT_TOP = 5; // /* Row0=Left   Col0=Top                Rotate 90 CC & Flip V   */
		public const int IG_ORIENT_RIGHT_TOP = 6; // /* Row0=Right  Col0=Top                Rotate 90 C      (landscape)*/
		public const int IG_ORIENT_RIGHT_BOTTOM = 7; // /* Row0=Right  Col0=Bottom     Rotate 90 C & Flip V            */
		public const int IG_ORIENT_LEFT_BOTTOM = 8; // /* Row0=Left   Col0=Bottom     Rotate 90 CC (landscape)*/
		
		
		///* constannts for threshold color reduction                                                                                    */
		public const int IG_REDUCE_BITONAL_GRAYSCALE = 0;
		public const int IG_REDUCE_BITONAL_AVE = 1;
		public const int IG_REDUCE_BITONAL_WEIGHTED = 2;
		
		///* JPEG decimation constans                                                */
		public const int IG_JPG_DCM_1x1_1x1_1x1 = 0;
		public const int IG_JPG_DCM_2x1_1x1_1x1 = 1;
		public const int IG_JPG_DCM_1x2_1x1_1x1 = 2;
		public const int IG_JPG_DCM_2x2_1x1_1x1 = 3;
		public const int IG_JPG_DCM_2x2_2x1_2x1 = 4;
		public const int IG_JPG_DCM_4x2_1x1_1x1 = 5;
		public const int IG_JPG_DCM_2x4_1x1_1x1 = 6;
		public const int IG_JPG_DCM_4x1_1x1_1x1 = 7;
		public const int IG_JPG_DCM_1x4_1x1_1x1 = 8;
		public const int IG_JPG_DCM_4x1_2x1_2x1 = 9;
		public const int IG_JPG_DCM_1x4_1x2_1x2 = 10;
		public const int IG_JPG_DCM_4x4_2x2_2x2 = 11;
		
		///***************************************************************************/
		///* ImageGear macros for all supported file formats.                        */
		///*                                                                         */
		///* Keep list sorted and do not change numbering.A  dd new formats between  */
		///* existing ones                                                           */
		///*                                                                         */
		///***************************************************************************/
		
		public const int IG_FORMAT_UNKNOWN = 0;
		public const int IG_FORMAT_ATT = 1;
		public const int IG_FORMAT_BMP = 2;
		public const int IG_FORMAT_BRK = 3;
		public const int IG_FORMAT_CAL = 4;
		public const int IG_FORMAT_CLP = 5;
		public const int IG_FORMAT_CIF = 6;
		public const int IG_FORMAT_CUT = 7;
		public const int IG_FORMAT_DCX = 8;
		public const int IG_FORMAT_DIB = 9;
		public const int IG_FORMAT_EPS = 10;
		public const int IG_FORMAT_G3 = 11;
		public const int IG_FORMAT_G4 = 12;
		public const int IG_FORMAT_GEM = 13;
		public const int IG_FORMAT_GIF = 14;
		public const int IG_FORMAT_GX2 = 15;
		public const int IG_FORMAT_ICA = 16;
		public const int IG_FORMAT_ICO = 17;
		public const int IG_FORMAT_IFF = 18;
		public const int IG_FORMAT_IGF = 19;
		public const int IG_FORMAT_IMT = 20;
		public const int IG_FORMAT_JPG = 21;
		public const int IG_FORMAT_KFX = 22;
		public const int IG_FORMAT_LV = 23;
		public const int IG_FORMAT_MAC = 24;
		public const int IG_FORMAT_MSP = 25;
		public const int IG_FORMAT_MOD = 26;
		public const int IG_FORMAT_NCR = 27;
		public const int IG_FORMAT_PBM = 28;
		public const int IG_FORMAT_PCD = 29;
		public const int IG_FORMAT_PCT = 30;
		public const int IG_FORMAT_PCX = 31;
		public const int IG_FORMAT_PGM = 32;
		public const int IG_FORMAT_PNG = 33;
		public const int IG_FORMAT_PNM = 34;
		public const int IG_FORMAT_PPM = 35;
		public const int IG_FORMAT_PSD = 36;
		public const int IG_FORMAT_RAS = 37;
		public const int IG_FORMAT_SGI = 38;
		public const int IG_FORMAT_TGA = 39;
		public const int IG_FORMAT_TIF = 40;
		public const int IG_FORMAT_TXT = 41;
		public const int IG_FORMAT_WPG = 42;
		public const int IG_FORMAT_XBM = 43;
		public const int IG_FORMAT_WMF = 44;
		public const int IG_FORMAT_XPM = 45;
		public const int IG_FORMAT_XRX = 46;
		public const int IG_FORMAT_XWD = 47;
		public const int IG_FORMAT_DCM = 48;
		public const int IG_FORMAT_AFX = 49;
		public const int IG_FORMAT_FPX = 50;
		public const int IG_FORMAT_PJPEG = 21;
		public const int IG_FORMAT_AVI = 52;
		public const int IG_FORMAT_G32D = 53;
		public const int IG_FORMAT_ABIC_BILEVEL = 54;
		public const int IG_FORMAT_ABIC_CONCAT = 55;
		public const int IG_FORMAT_PDF = 56;
		public const int IG_FORMAT_JBIG = 57;
		public const int IG_FORMAT_RAW = 58;
		public const int IG_FORMAT_IMR = 59;
		public const int IG_FORMAT_STX = 60;
		
		
		///***************************************************************************/
		///* ImageGear macros for all compression types.                             */
		///***************************************************************************/
		
		public const int IG_COMPRESSION_NONE = 0; // /* No compression                */
		public const int IG_COMPRESSION_PACKED_BITS = 1; // /* Packed bits compression       */
		public const int IG_COMPRESSION_HUFFMAN = 2; // /* Huffman encoding              */
		public const int IG_COMPRESSION_CCITT_G3 = 3; // /* CCITT Group 3                 */
		public const int IG_COMPRESSION_CCITT_G4 = 4; // /* CCITT Group 4                 */
		public const int IG_COMPRESSION_CCITT_G32D = 5; // /* CCITT Group 3 2D              */
		public const int IG_COMPRESSION_JPEG = 6; // /* JPEG compression              */
		public const int IG_COMPRESSION_RLE = 7; // /* Run length encoding           */
		
		///* The following compression algorithms require special licensing          */
		public const int IG_COMPRESSION_LZW = 8; // /* LZW compression               */
		public const int IG_COMPRESSION_ABIC_BW = 9; // /* IBM ABIC compression          */
		public const int IG_COMPRESSION_ABIC_GRAY = 10; // /* IBM ABIC compression          */
		public const int IG_COMPRESSION_JBIG = 11; // /* IBM JBIG compression          */
		public const int IG_COMPRESSION_FPX_SINCOLOR = 12; // /* single color compression                                               */
		public const int IG_COMPRESSION_FPX_NOCHANGE = 13; // /* save with the same compression as loaded       */
		
		public const int IG_COMPRESSION_DEFLATE = 14;
		public const int IG_COMPRESSION_IBM_MMR = 15;
		public const int IG_COMPRESSION_ABIC = 16; // /* IBM ABIC compression          */
		
		public const int IG_COMPRESSION_PROGRESSIVE = 17; // /* Progressive compression ( Progressive JPEG and may be PNG in future ) */
		
		///***************************************************************************/
		///* Format types used for saving image files                                */
		///***************************************************************************/
		
		public static readonly int IG_SAVE_UNKNOWN = (IG_FORMAT_UNKNOWN);
		public static readonly int IG_SAVE_BMP_UNCOMP = (IG_FORMAT_BMP | (IG_COMPRESSION_NONE * 65536));
		public static readonly int IG_SAVE_BMP_RLE = (IG_FORMAT_BMP | (IG_COMPRESSION_RLE * 65536));
		public static readonly int IG_SAVE_BRK_G3 = (IG_FORMAT_BRK | (IG_COMPRESSION_CCITT_G3 * 65536));
		public static readonly int IG_SAVE_BRK_G3_2D = (IG_FORMAT_BRK | (IG_COMPRESSION_CCITT_G32D * 65536));
		public static readonly int IG_SAVE_CAL = (IG_FORMAT_CAL);
		public static readonly int IG_SAVE_CLP = (IG_FORMAT_CLP);
		public static readonly int IG_SAVE_DCX = (IG_FORMAT_DCX);
		public static readonly int IG_SAVE_EPS = (IG_FORMAT_EPS);
		public static readonly int IG_SAVE_GIF = (IG_FORMAT_GIF);
		public static readonly int IG_SAVE_ICA_G3 = (IG_FORMAT_ICA | (IG_COMPRESSION_CCITT_G3 * 65536));
		public static readonly int IG_SAVE_ICA_G4 = (IG_FORMAT_ICA | (IG_COMPRESSION_CCITT_G4 * 65536));
		public static readonly int IG_SAVE_ICA_IBM_MMR = (IG_FORMAT_ICA | (IG_COMPRESSION_IBM_MMR * 65536));
		public static readonly int IG_SAVE_ICO = (IG_FORMAT_ICO);
		public static readonly int IG_SAVE_IMT = (IG_FORMAT_IMT);
		public static readonly int IG_SAVE_IFF = (IG_FORMAT_IFF);
		public static readonly int IG_SAVE_JPG = (IG_FORMAT_JPG);
		public static readonly int IG_SAVE_PJPEG = (IG_FORMAT_PJPEG | (IG_COMPRESSION_PROGRESSIVE * 65536));
		public static readonly int IG_SAVE_MOD_G3 = (IG_FORMAT_MOD | (IG_COMPRESSION_CCITT_G3 * 65536));
		public static readonly int IG_SAVE_MOD_G4 = (IG_FORMAT_MOD | (IG_COMPRESSION_CCITT_G4 * 65536));
		public static readonly int IG_SAVE_MOD_IBM_MMR = (IG_FORMAT_MOD | (IG_COMPRESSION_IBM_MMR * 65536));
		public static readonly int IG_SAVE_NCR = (IG_FORMAT_NCR);
		public static readonly int IG_SAVE_NCR_G4 = (IG_FORMAT_NCR | (IG_COMPRESSION_CCITT_G4 * 65536));
		public static readonly int IG_SAVE_PBM_ASCII = (IG_FORMAT_PBM);
		public static readonly int IG_SAVE_PBM_RAW = (IG_FORMAT_PBM | (IG_COMPRESSION_PACKED_BITS * 65536));
		public static readonly int IG_SAVE_PCT = (IG_FORMAT_PCT);
		public static readonly int IG_SAVE_PCX = (IG_FORMAT_PCX);
		public static readonly int IG_SAVE_PNG = (IG_FORMAT_PNG);
		public static readonly int IG_SAVE_PSD = (IG_FORMAT_PSD);
		public static readonly int IG_SAVE_RAS = (IG_FORMAT_RAS);
		public static readonly int IG_SAVE_RAW_G3 = (IG_FORMAT_G3 | (IG_COMPRESSION_CCITT_G3 * 65536));
		public static readonly int IG_SAVE_RAW_G4 = (IG_FORMAT_G4 | (IG_COMPRESSION_CCITT_G4 * 65536));
		public static readonly int IG_SAVE_RAW_G32D = (IG_FORMAT_G3 | (IG_COMPRESSION_CCITT_G32D * 65536));
		public static readonly int IG_SAVE_RAW_JPG = (IG_FORMAT_UNKNOWN | (IG_COMPRESSION_JPEG * 65536));
		public static readonly int IG_SAVE_RAW_LZW = (IG_FORMAT_UNKNOWN | (IG_COMPRESSION_LZW * 65536));
		public static readonly int IG_SAVE_RAW_RLE = (IG_FORMAT_UNKNOWN | (IG_COMPRESSION_RLE * 65536));
		public static readonly int IG_SAVE_SGI = (IG_FORMAT_SGI);
		public static readonly int IG_SAVE_TGA = (IG_FORMAT_TGA);
		public static readonly int IG_SAVE_TIF_UNCOMP = (IG_FORMAT_TIF | (IG_COMPRESSION_NONE * 65536));
		public static readonly int IG_SAVE_TIF_G3 = (IG_FORMAT_TIF | (IG_COMPRESSION_CCITT_G3 * 65536));
		public static readonly int IG_SAVE_TIF_G3_2D = (IG_FORMAT_TIF | (IG_COMPRESSION_CCITT_G32D * 65536));
		public static readonly int IG_SAVE_TIF_G4 = (IG_FORMAT_TIF | (IG_COMPRESSION_CCITT_G4 * 65536));
		public static readonly int IG_SAVE_TIF_HUFFMAN = (IG_FORMAT_TIF | (IG_COMPRESSION_HUFFMAN * 65536));
		public static readonly int IG_SAVE_TIF_JPG = (IG_FORMAT_TIF | (IG_COMPRESSION_JPEG * 65536));
		public static readonly int IG_SAVE_TIF_LZW = (IG_FORMAT_TIF | (IG_COMPRESSION_LZW * 65536));
		public static readonly int IG_SAVE_TIF_PACKED = (IG_FORMAT_TIF | (IG_COMPRESSION_PACKED_BITS * 65536));
		public static readonly int IG_SAVE_XBM = (IG_FORMAT_XBM);
		public static readonly int IG_SAVE_XPM = (IG_FORMAT_XPM);
		public static readonly int IG_SAVE_XWD = (IG_FORMAT_XWD);
		public static readonly int IG_SAVE_WMF = (IG_FORMAT_WMF);
		public static readonly int IG_SAVE_DCM = (IG_FORMAT_DCM);
		
		public static readonly int IG_SAVE_FPX_NOCHANGE = (IG_FORMAT_FPX | (IG_COMPRESSION_FPX_NOCHANGE * 65536));
		public static readonly int IG_SAVE_FPX_UNCOMP = (IG_FORMAT_FPX | (IG_COMPRESSION_NONE * 65536));
		public static readonly int IG_SAVE_FPX_JPG = (IG_FORMAT_FPX | (IG_COMPRESSION_JPEG * 65536));
		public static readonly int IG_SAVE_FPX_SINCOLOR = (IG_FORMAT_FPX | (IG_COMPRESSION_FPX_SINCOLOR * 65536));
		
		public static readonly int IG_SAVE_JBIG = (IG_FORMAT_JBIG);
		
		///************************************************************************************/
		///* ImageGear image control option IDs                                               */
		///************************************************************************************/
		///*      Option ID                            Format         Or  Opt #    lpData type*/
		///*      --------------------------------     ---------------------    ------------- */
		///************************************************************************************/
		public static readonly int IG_CONTROL_JPG_QUALITY = (IG_FORMAT_JPG | 256); // /* UINT        */
		public static readonly int IG_CONTROL_JPG_DECIMATION_TYPE = (IG_FORMAT_JPG | 512); // /* DWORD       */
		public static readonly int IG_CONTROL_JPG_SAVE_THUMBNAIL = (IG_FORMAT_JPG | 768); // /* BOOL        */
		public static readonly int IG_CONTROL_JPG_THUMBNAIL_WIDTH = (IG_FORMAT_JPG | 1024); // /* UINT        */
		public static readonly int IG_CONTROL_JPG_THUMBNAIL_HEIGHT = (IG_FORMAT_JPG | 1280); // /* UINT        */
		public static readonly int IG_CONTROL_JPG_KEEP_ALPHA = (IG_FORMAT_JPG | 1536); // /* BOOL                 */
		public static readonly int IG_CONTROL_JPG_TYPE = (IG_FORMAT_JPG | 1792); // /* BOOL        */
		public static readonly int IG_CONTROL_JPG_PREDICTOR = (IG_FORMAT_JPG | 2048); // /* UINT        */
		public static readonly int IG_CONTROL_JPG_SCAN_INFO = (IG_FORMAT_JPG | 2304); // /*     LPAT_SCANINFO           */
		public static readonly int IG_CONTROL_JPG_SCAN_INFO_COUNT = (IG_FORMAT_JPG | 2560); // /*     UINT            */
		public static readonly int IG_CONTROL_JPG_LOAD_SCANS = (IG_FORMAT_JPG | 2816); // /*     UINT            */
		
		public static readonly int IG_CONTROL_PJPEG_SCAN_INFO = (IG_CONTROL_JPG_SCAN_INFO); // /*     LPAT_SCANINFO           */
		public static readonly int IG_CONTROL_PJPEG_SCAN_INFO_COUNT = (IG_CONTROL_JPG_SCAN_INFO_COUNT); // /*     UINT            */
		public static readonly int IG_CONTROL_PJPEG_LOAD_SCANS = (IG_CONTROL_JPG_LOAD_SCANS); // /*     UINT            */
		
		public static readonly int IG_CONTROL_TXT_XDPI = (IG_FORMAT_TXT | 256); // /* UINT        */
		public static readonly int IG_CONTROL_TXT_YDPI = (IG_FORMAT_TXT | 512); // /* UINT        */
		public static readonly int IG_CONTROL_TXT_MARGIN_LEFT = (IG_FORMAT_TXT | 768); // /* AT_DIMENSION*/
		public static readonly int IG_CONTROL_TXT_MARGIN_TOP = (IG_FORMAT_TXT | 1024); // /* AT_DIMENSION*/
		public static readonly int IG_CONTROL_TXT_MARGIN_RIGHT = (IG_FORMAT_TXT | 1280); // /* AT_DIMENSION*/
		public static readonly int IG_CONTROL_TXT_MARGIN_BOTTOM = (IG_FORMAT_TXT | 1536); // /* AT_DIMENSION*/
		public static readonly int IG_CONTROL_TXT_PAGE_WIDTH = (IG_FORMAT_TXT | 1792); // /* AT_DIMENSION*/
		public static readonly int IG_CONTROL_TXT_PAGE_HEIGHT = (IG_FORMAT_TXT | 2048); // /* AT_DIMENSION*/
		public static readonly int IG_CONTROL_TXT_POINT_SIZE = (IG_FORMAT_TXT | 2304); // /* INT         */
		public static readonly int IG_CONTROL_TXT_WEIGHT = (IG_FORMAT_TXT | 2560); // /* BOOL        */
		public static readonly int IG_CONTROL_TXT_ITALIC = (IG_FORMAT_TXT | 2816); // /* BOOL        */
		public static readonly int IG_CONTROL_TXT_TAB_STOP = (IG_FORMAT_TXT | 3072); // /* UINT        */
		public static readonly int IG_CONTROL_TXT_TYPEFACE = (IG_FORMAT_TXT | 3328); // /* CHAR[32]    */
		public static readonly int IG_CONTROL_TXT_LINES_PER_PAGE = (IG_FORMAT_TXT | 3584); // /* UINT        */
		public static readonly int IG_CONTROL_TXT_CHAR_PER_LINE = (IG_FORMAT_TXT | 3840); // /* UINT        */
		public static readonly int IG_CONTROL_TXT_COMPATIBILITY_MODE = (IG_FORMAT_TXT | 4896); // /* BOOL        */
		
		
		
		
		public static readonly int IG_CONTROL_BMP_TYPE = (IG_FORMAT_BMP | 256); // /* UINT        */
		public static readonly int IG_CONTROL_BMP_UPSIDEDOWN = (IG_FORMAT_BMP | 512); // /* BOOL        */
		public static readonly int IG_CONTROL_BMP_16GRAY_SCANNER = (IG_FORMAT_BMP | 768); // /* BOOL        */
		public static readonly int IG_CONTROL_BMP_16GRAY_SCANNER_TYPE = (IG_FORMAT_BMP | 1024); // /* UINT        */
		
		
		public static readonly int IG_CONTROL_TIF_FILENAME_LEN = (IG_FORMAT_TIF | 256); // /* UINT        */
		public static readonly int IG_CONTROL_TIF_FILENAME = (IG_FORMAT_TIF | 512); // /* LPSTR       */
		public static readonly int IG_CONTROL_TIF_FILEDATE_LEN = (IG_FORMAT_TIF | 768); // /* UINT        */
		public static readonly int IG_CONTROL_TIF_FILEDATE = (IG_FORMAT_TIF | 1024); // /* LPSTR       */
		public static readonly int IG_CONTROL_TIF_FORCE_SNGL_STRIP = (IG_FORMAT_TIF | 1280); // /* BOOL        */
		public static readonly int IG_CONTROL_TIF_BUFFER_SIZE = (IG_FORMAT_TIF | 1536); // /* DWORD       */
		public static readonly int IG_CONTROL_TIF_WRITE_FILL_ORDER = (IG_FORMAT_TIF | 1792); // /*     SHORT                   */
		public static readonly int IG_CONTROL_TIF_WRITE_CONFIG = (IG_FORMAT_TIF | 2048); // /* SHORT        */
		public static readonly int IG_CONTROL_TIF_PHOTOMETRIC = (IG_FORMAT_TIF | 2304); //   /* SHORT       */
		public static readonly int IG_CONTROL_TIF_BIGENDIAN = (IG_FORMAT_TIF | 2560); // /* BOOL        */
		public static readonly int IG_CONTROL_TIF_DOCUMENTNAME = (IG_FORMAT_TIF | 2816); // /* LPSTR (maxlen=256) */
		public static readonly int IG_CONTROL_TIF_DATETIME = (IG_FORMAT_TIF | 3072); // /* LPSTR (maxlen=256) */
		public static readonly int IG_CONTROL_TIF_IMAGE_BEFORE_IFD = (IG_FORMAT_TIF | 3328); // /* BOOL        */
		public static readonly int IG_CONTROL_TIF_PLANAR = (IG_FORMAT_TIF | 3584); // /* BOOL        */
		public static readonly int IG_CONTROL_TIF_NUMBER_OF_STRIPS = (IG_FORMAT_TIF | 3840); // /* LONG       */
		public static readonly int IG_CONTROL_TIF_WRITE_CLASS_F = (IG_FORMAT_TIF | 4096); // /* BOOL                        */
		public static readonly int IG_CONTROL_TIF_16_UPDATE_LUT = (IG_FORMAT_TIF | 4352); // /* BOOL                        */
		
		public static readonly int IG_CONTROL_TIF_NEW_SUBFILE_TYPE = (IG_FORMAT_TIF | -24576); // /* UINT                        */
		public static readonly int IG_CONTROL_TIF_INCLUDE_PAGE_NUMBER = (IG_FORMAT_TIF | -24320); // /* BOOL                        */
		
		
		public static readonly int IG_CONTROL_GIF_INTERLACE = (IG_FORMAT_GIF | 256); // /* BOOL        */
		public static readonly int IG_CONTROL_GIF_ADD_IMAGE = (IG_FORMAT_GIF | 512); // /* BOOL        */
		public static readonly int IG_CONTROL_GIF_VERSION = (IG_FORMAT_GIF | 768); // /* BYTE        */
		public static readonly int IG_CONTROL_GIF_EXTBLOCKREADONLY = (IG_FORMAT_GIF | 1024); // /* BOOL        */
		
		public static readonly int IG_CONTROL_AVI_FILENAME = (IG_FORMAT_AVI | 256); // /* CHAR[262]   */
		
		public static readonly int IG_CONTROL_KFX_BIT_SEX = (IG_FORMAT_KFX | 256); // /* UINT        */
		
		public static readonly int IG_CONTROL_PCT_VERSION1 = (IG_FORMAT_PCT | 256); // /* BOOL        */
		
		public static readonly int IG_CONTROL_TGA_SAVE_THUMBNAIL = (IG_FORMAT_TGA | 256); // /* BOOL        */
		public static readonly int IG_CONTROL_TGA_THUMBNAIL_WIDTH = (IG_FORMAT_TGA | 512); // /* UINT        */
		public static readonly int IG_CONTROL_TGA_THUMBNAIL_HEIGHT = (IG_FORMAT_TGA | 768); // /* UINT        */
		public static readonly int IG_CONTROL_TGA_KEEP_ALPHA = (IG_FORMAT_TGA | 1024); // /* BOOL        */
		public static readonly int IG_CONTROL_TGA_CONVERT_TO_16 = (IG_FORMAT_TGA | 1280); // /* BOOL        */
		
		public static readonly int IG_CONTROL_EPS_TIFF_PREVIEW = (IG_FORMAT_EPS | 256); // /* BOOL                        */
		public static readonly int IG_CONTROL_EPS_FIT_TO_PAGE = (IG_FORMAT_EPS | 512); // /* BOOL                        */
		public static readonly int IG_CONTROL_EPS_ACTUAL_SIZE = (IG_FORMAT_EPS | 768); // /* BOOL                        */
		public static readonly int IG_CONTROL_EPS_PIXEL_TO_PIXEL = (IG_FORMAT_EPS | 1024); // /* BOOL                        */
		public static readonly int IG_CONTROL_EPS_PAGE_WIDTH = (IG_FORMAT_EPS | 1280); // /* AT_DIMENSION*/
		public static readonly int IG_CONTROL_EPS_PAGE_HEIGHT = (IG_FORMAT_EPS | 1536); // /* AT_DIMENSION*/
		public static readonly int IG_CONTROL_EPS_XDPI = (IG_FORMAT_EPS | 1792); //  /* UINT        */
		public static readonly int IG_CONTROL_EPS_YDPI = (IG_FORMAT_EPS | 2048); //  /* UINT        */
		
		public static readonly int IG_CONTROL_WMF_LOAD_METAFILE = (IG_FORMAT_WMF | 256); // /* BOOL                     */
		
		public static readonly int IG_CONTROL_PNG_COMPRESSION = (IG_FORMAT_PNG | 256); // /*    UINT                    */
		
		public static readonly int IG_CONTROL_JBIG_STRIP_SIZE = (IG_FORMAT_JBIG | 768); // /*   DWORD                   */
		public static readonly int IG_CONTROL_JBIG_TYPICAL_PREDICTOR = (IG_FORMAT_JBIG | 1024); // /*   INT                     */
		public static readonly int IG_CONTROL_JBIG_CONTEXT_SHAPE = (IG_FORMAT_JBIG | 1280); // /*       INT                     */
		public static readonly int IG_CONTROL_JBIG_TAUX = (IG_FORMAT_JBIG | 1536); // /*        INT                     */
		
		///*     additional      constants for Filters   */
		
		public const int IG_TIF_STRIP_FIXED_COUNT = 0;
		public const int IG_TIF_STRIP_FIXED_BUFFER = 1;
		public const int IG_TIF_TILED_FIXED_SIZE = 16;
		public const int IG_TIF_TILED_FIXED_COUNT = 17;
		
		public const int IG_TIF_PHOTO_WHITEZERO = 0;
		public const int IG_TIF_PHOTO_BLACKZERO = 1;
		public const int IG_TIF_PHOTO_RGB = 2;
		public const int IG_TIF_PHOTO_CMYK = 5;
		
		public const int IG_PNG_MIN_COMPRESSION = 0;
		public const int IG_PNG_MAX_COMPRESSION = 9;
		public const int IG_PNG_DEFAULT_COMPRESSION = 6;
		
		
		public const int IG_PNG_STRIP_FIXED_COUNT = 0;
		public const int IG_PNG_STRIP_FIXED_BUFFER = 1;
		
		public const int IG_JPG_LOSSY = 0;
		public const int IG_JPG_LOSSLESS = 1;
		public const int IG_JPG_PROGRESSIVE = 2;
		
		///**************************************************************************/
		///*                             STANDARD PAGE SIZES                                                                                                               */
		///**************************************************************************/
		
		public const int IG_ASCIIXSIZELETTER = 8500; //                /* 8 1/2"  */
		public const int IG_ASCIIYSIZELETTER = 11000; //        /* 11"    */
		
		public const int IG_ASCIIXSIZELEGAL = 8500; //        /* 8 1/2"  */
		public const int IG_ASCIIYSIZELEGAL = 14000; //        /* 14"    */
		
		public const int IG_ASCIIXSIZEEXECUTIVE = 7250; //                /* 7 1/4"  */
		public const int IG_ASCIIYSIZEEXECUTIVE = 10500; //        /* 10 1/2" */
		
		public const int IG_ASCIIXSIZEENVELOPE = 4125; //                /* 4 1/8"  */
		public const int IG_ASCIIYSIZEENVELOPE = 9500; //                /* 9 1/2"  */
		
		
		//**********************************************************************************************
		
		// GUI window constants - use with GUIWindow property
		public const int GUIPAN = 0;
		public const int GUIMAG = 1;
		public const int GUIPAL = 2;
		public const int GUITHM = 3;
		public const int GUIHST = 4;
		public const int GUIPXL = 5;
		public const int GUISRT = 6;
		
		//Global Const IG_LOADDOC_DISPLAY_FIRST = 0
		//Global Const IG_LOADDOC_DISPLAY_ALL = 1
		
		// Setting mode constants - use with SettingMode property
		public const int MODE_CONTRAST = 0;
		public const int MODE_MAXCOLORS = 1;
		public const int MODE_FASTREMAP = 2;
		public const int MODE_ROTATE = 3;
		public const int MODE_BLURAMOUNT = 4;
		public const int MODE_DIRECTION = 5;
		public const int MODE_TWISTTYPE = 6;
		public const int MODE_PRINTDRIVER = 7;
		public const int MODE_DPIASPECT = 8;
		public const int MODE_ZOOMKEYS = 9;
		public const int MODE_LOADDOC = 10;
		public const int MODE_USE_BKGRND = 11;
		public const int MODE_ROTATE_DEV_RECT = 12;
		public const int MODE_PRINT_ADJUST = 13;
		public const int MODE_STITCH_IMAGE = 14;
		public const int MODE_USE_FIRETAGEX = 15;
		public const int MODE_MAG_BUTTON = 16;
		public const int MODE_PAN_BUTTON = 17;
		public const int MODE_SELECT_BUTTON = 18;
		
		///* Mouse button constants */
		
		public const int IG_VK_LBUTTON = 1;
		public const int IG_VK_RBUTTON = 2;
		public const int IG_VK_MBUTTON = 4;
		
		
		// Thumbnail settings - use with ThumbOptionMode, ThumbOptionValue
		public const int IG_GUI_THUMBNAIL_WIDTH = 0;
		public const int IG_GUI_THUMBNAIL_HEIGHT = 1;
		public const int IG_GUI_THUMBNAIL_SHOW_TITLE = 2;
		public const int IG_GUI_THUMBNAIL_X_SPACING = 3;
		public const int IG_GUI_THUMBNAIL_Y_SPACING = 4;
		public const int IG_GUI_THUMBNAIL_SHOW_FLAT = 5;
		public const int IG_GUI_THUMBNAIL_BORDER_WIDTH = 6;
		public const int IG_GUI_THUMBNAIL_SHADOW_WIDTH = 7;
		public const int IG_GUI_THUMBNAIL_ZOOM_FACTOR = 8;
		public const int IG_GUI_THUMBNAIL_INTERIOR = 9;
		public const int IG_GUI_THUMBNAIL_MAGNIFY_FLAG = 10;
		public const int IG_GUI_THUMBNAIL_TITLE_HEIGHT = 11;
		public const int IG_GUI_THUMBNAIL_USE_EMBEDDED = 12;
		public const int IG_GUI_THUMBNAIL_ALL_PAGES = 13;
		public const int IG_GUI_THUMBNAIL_TITLE_STYLE = 14;
		
		public const int IG_THUMB_TITLE_FILENAME = 0;
		public const int IG_THUMB_TITLE_PAGENUM = 1;
		public const int IG_THUMB_TITLE_EVENT = 2;
	}
}